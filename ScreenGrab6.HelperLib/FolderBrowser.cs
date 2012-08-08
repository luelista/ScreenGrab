using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Collections;
using System.Globalization;
using System.Runtime.InteropServices;
using ShellDll;
using System.IO;

namespace DirectoryBrowser
{
    #region Delegates

    // This delegate is used for the ContextMenuHoverEvent
    public delegate void ContextMenuMouseHoverEventHandler(object sender, ContextMenuMouseHoverEventArgs e);

    // This delegate is used for the SelectedFolderChangedEvent
    public delegate void SelectedFolderChangedEventHandler(object sender, SelectedFolderChangedEventArgs e);

    #endregion

    #region SpecialFolders

    /// <summary>
    /// This enum is used to indicate which folder should be opened when initialising the browser.
    /// When 'Other' is chosen, the browser will start in the directory given by the StartUpDirectoryOther
    /// property.
    /// </summary>
    public enum SpecialFolders : uint
    {
        UserProfiles = 0x003e,
        DesktopDir_All = 0x0019,
        ApplicationData_All = 0x0023,
        MyDocuments_All = 0x002e,
        MyFavorites_All = 0x001f,
        MyMusic_All = 0x0035,
        MyPictures_All = 0x0036,
        StartMenu_All = 0x0016,
        MyVideos_All = 0x0037,

        Desktop = 0x0000,
        DekstopDir = 0x0010,
        MyComputer = 0x0011,
        MyFavorites = 0x0006,
        ApplicationData = 0x001c,
        MyDocuments = 0x000c,
        MyMusic = 0x000d,
        MyPictures = 0x0027,
        MyVideos = 0x000e,
        MyNetworkPlaces = 0x0012,
        MyDocumentsDir = 0x0005,
        StartMenu = 0x000b,

        ControlPanel = 0x0003,
        Printers = 0x0004,
        ProgramFiles = 0x0026,
        SendTo = 0x0009,
        System = 0x0025,
        Windows = 0x0024,
        RecycleBin = 0x000a,

        Other = 0x1000
    }

    #endregion

    /// <summary>
    /// This control is used to browse the files and folders on your computer as with Windows Explorer
    /// </summary>
    public partial class FolderBrowser : UserControl
    {
        #region Fields

        // The shellbrowser used by this browser to get the shellitems of all files and folders
        private ShellBrowser shellBrowser;

        // These wrappers are used for accepting drops on the browser
        private BrowserTVDropWrapper tvDropWrapper;

        // These wrappers are used to allow dragging from the browser
        private BrowserTVDragWrapper tvDragWrapper;

        // These wrappers are used to create the standard context menu's, like in Windows Explorer
        private BrowserTVContextMenuWrapper tvContextWrapper;

        // This field is used to store the control from where dragging has started
        private Control dragStartControl;

        // When this bool is true, selecting a node will change the current directory, 
        // otherwise the current directory won't change
        private bool selectionChange = true, newItemCreated;
        
        // These fields are used to determine the directory to start the browser in
        private SpecialFolders startupDir = SpecialFolders.MyComputer;
        private string otherStartupDir = string.Empty;

        // Selected node and item are the TreeNode and ShellItem of the current directory
        private TreeNode selectedNode;
        private ShellItem selectedItem;

        // These TreeNodes are used very often, so need own fields. They are for the Root (Desktop) and My Computer.
        private TreeNode desktopNode, myCompNode;

        private Thread updateThread;
        private UpdateInvoker updateInvoker;
        private bool updating;

        private bool handleCreated;

        private delegate void UpdateInvoker(object sender, ShellItemUpdateEventArgs e);

        #region Events

        /// <summary>
        /// These event will be raised when the mouse moves over a contextmenu item. This event is used to show the 
        /// help text with that contextmenu item (just like the help text in the statusbar of Windows Explorer).
        /// </summary>
        public event ContextMenuMouseHoverEventHandler ContextMenuMouseHover;
        
        /// <summary>
        /// This event will be raised every time the current directory changes. It will include the new current TreeNode,
        /// ShellItem and the full path to that directory.
        /// </summary>
        public event SelectedFolderChangedEventHandler SelectedFolderChanged;

        #endregion

        #endregion

        public FolderBrowser()
        {
            InitializeComponent();

            InitBrowser();
            InitFolderView();
        }

        #region Init Browser

        #region At Constructor

        /// <summary>
        /// Inits the shellbrowser and registeres some events
        /// </summary>
        private void InitBrowser()
        {
            updateInvoker = new UpdateInvoker(ShellItemUpdateInvoke);

            HandleCreated += new EventHandler(FileBrowser_HandleCreated);
            HandleDestroyed += new EventHandler(FileBrowser_HandleDestroyed);
        }

        /// <summary>
        /// Registers the needed events of the TreeView control
        /// </summary>
        private void InitFolderView()
        {
            folderView.BeforeExpand += new TreeViewCancelEventHandler(folderView_BeforeExpand);
            folderView.BeforeSelect += new TreeViewCancelEventHandler(folderView_BeforeSelect);
            folderView.AfterSelect += new TreeViewEventHandler(folderView_AfterSelect);

            folderView.SetSorting(true);
        }

        #endregion

        #region After Handle Created

        /// <summary>
        /// Initialises the ContextMenu wrappers
        /// </summary>
        private void InitContextMenu()
        {
          tvContextWrapper = new BrowserTVContextMenuWrapper(this);
        }

        /// <summary>
        /// If the browser allows dropping, the wrappers for drag/drop are initialised and the events are registered
        /// </summary>
        private void InitDragDrop()
        {
            if (AllowDrop)
            {
              tvDropWrapper = new BrowserTVDropWrapper(this);
              tvDropWrapper.Drop += new DropEventHandler(DropWrapper_Drop);
              tvDragWrapper = new BrowserTVDragWrapper(this);
              tvDragWrapper.DragStart += new DragEnterEventHandler(DragWrapper_DragStart);
                tvDragWrapper.DragEnd += new EventHandler(DragWrapper_DragEnd);
            }
        }

        /// <summary>
        /// Selects the startup directory of the browser
        /// </summary>
        private void InitStartUp()
        {
            if (startupDir != SpecialFolders.Other)
                SelectPath(startupDir, true);
            else
                SelectPath(otherStartupDir, true);

            folderView.Focus();
        }

        /// <summary>
        /// Initialises the base ShellItems, including the Desktop and all it's children and the children of My Computer.
        /// These items are also added to the TreeView and the navigation bar.
        /// </summary>
        private void InitBaseItems()
        {
            if (ShellBrowser == null)
                ShellBrowser = new ShellBrowser();

            desktopNode = new TreeNode(
                ShellBrowser.DesktopItem.Text,
                ShellBrowser.DesktopItem.ImageIndex,
                ShellBrowser.DesktopItem.SelectedImageIndex);
            desktopNode.Tag = ShellBrowser.DesktopItem;
            desktopNode.Name = desktopNode.Text;

            folderView.Nodes.Add(desktopNode);

            selectedNode = desktopNode;
            selectedItem = ShellBrowser.DesktopItem;

            ShellBrowser.DesktopItem.Expand(false, true, IntPtr.Zero);

            foreach (ShellItem desktopChild in ShellBrowser.DesktopItem.SubFolders)
            {
                TreeNode desktopChildNode = new TreeNode(
                    desktopChild.Text,
                    desktopChild.ImageIndex,
                    desktopChild.SelectedImageIndex);
                desktopChildNode.Tag = desktopChild;
                desktopChildNode.Name = desktopChildNode.Text;

                if (desktopChildNode.Text == ShellBrowser.MyComputerName)
                {
                    myCompNode = desktopChildNode;
                    desktopChild.Expand(false, true, IntPtr.Zero);

                    foreach (ShellItem myCompChild in desktopChild.SubFolders)
                    {
                        TreeNode myCompChildNode = new TreeNode(
                            myCompChild.Text,
                            myCompChild.ImageIndex,
                            myCompChild.SelectedImageIndex);
                        myCompChildNode.Tag = myCompChild;
                        myCompChildNode.Name = myCompChildNode.Text;

                        if (myCompChild.HasSubfolder)
                            myCompChildNode.Nodes.Add(string.Empty);

                        desktopChildNode.Nodes.Add(myCompChildNode);
                    }
                }
                else if (desktopChild.HasSubfolder)
                    desktopChildNode.Nodes.Add(string.Empty);

                desktopNode.Nodes.Add(desktopChildNode);
            }
        }

        private void InitUpdate()
        {
            updateThread = new Thread(new ThreadStart(UpdateLoop));
            updateThread.IsBackground = true;
            updating = true;

            ShellBrowser.ShellItemUpdate += new ShellItemUpdateEventHandler(shellBrowser_ShellItemUpdate);
            updateThread.Start();
        }

        #endregion

        #endregion

        #region Events

        #region Browser Events

        /// <summary>
        /// When the handle of the browser is created all wrappers are initialised and the startup directory is selected.
        /// Also the update thread will be started
        /// </summary>
        void FileBrowser_HandleCreated(object sender, EventArgs e)
        {
            InitBaseItems();
            InitContextMenu();
            InitDragDrop();
            InitStartUp();
            InitUpdate();

            GC.Collect();

            handleCreated = true;
        }

        /// <summary>
        /// When the handle is destroyed the update thread must be aborted
        /// </summary>
        void FileBrowser_HandleDestroyed(object sender, EventArgs e)
        {
            if (handleCreated)
            {
                handleCreated = false;

                folderView.Nodes.Clear();

                updating = false;

                ShellBrowser.UpdateCondition.ContinueUpdate = false;

                updateThread.IsBackground = false;
                updateThread.Join(5000);

                GC.Collect();
            }
        }

        #endregion

        #region FolderView Events

        /// <summary>
        /// If selectionChange is true, the current directory is changed after a TreeNode is selected, if that happens
        /// the ListView will be cleared and filled with the contents of the new directory and the 
        /// SelectedFolderChangeEvent will be raised
        /// </summary>
        void folderView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (selectionChange)
            {
                ShellItem oldItem = selectedItem;
                ShellItem newItem = e.Node.Tag as ShellItem;

                if (!ShellItem.Equals(oldItem, newItem))
                {
                    OnSelectedFolderChanged(new SelectedFolderChangedEventArgs(folderView.SelectedNode));
                }
            }
        }

        /// <summary>
        /// If selectionChange is true, before a node is selected, the node will be expanded if it's selected by
        /// Mouse or the ShellItem will be expanded and all nodes will be added
        /// </summary>
        void folderView_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (selectionChange)
            {
                ShellItem nodeItem = (ShellItem)e.Node.Tag;

                if (e.Action == TreeViewAction.ByMouse && !e.Node.IsExpanded)
                    e.Node.Expand();
                else
                    ExtendTreeNode(e.Node, false);
            }
        }

        /// <summary>
        /// Before a node is expanded, if the ShellItem hasn't been expanded or the child nodes haven't been added,
        /// this method will add all the children to the node.
        /// </summary>
        void folderView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            ShellItem nodeItem = (ShellItem)e.Node.Tag;

            Cursor.Current = Cursors.WaitCursor;
            e.Cancel = !ExtendTreeNode(e.Node, false);
            Cursor.Current = Cursors.Default;

            if (e.Cancel)
                e.Node.Nodes.Clear();
        }

        #endregion

        #endregion

        #region Generated Events

        /// <summary>
        /// This method will raise the OnSelectedFolderChangedEvent. Before raising it the navigation bar item is changed
        /// to match the new current directory and the selectedNode property is set to the new node.
        /// </summary>
        /// <param name="e">The SelectedFolderChangedEventArgs to pass on</param>
        private void OnSelectedFolderChanged(SelectedFolderChangedEventArgs e)
        {
            selectedNode = e.Node;

            if (SelectedFolderChanged != null)
                SelectedFolderChanged(this, e);
        }

        /// <summary>
        /// This method will raise the OnContextMenuMouseHoverEvent.
        /// </summary>
        /// <param name="e">The ContextMenuMouseHoverEventArgs to pass on</param>
        internal void OnContextMenuMouseHover(ContextMenuMouseHoverEventArgs e)
        {
            if (ContextMenuMouseHover != null)
                ContextMenuMouseHover(this, e);
        }

        #endregion

        #region Update File/Folder Changes

        private void UpdateLoop()
        {
            while (updating)
            {
                if (selectedItem != null)
                {
                    ShellBrowser.UpdateCondition.ContinueUpdate = true;
                    selectedItem.Update(true, true);
                }

                Thread.Sleep(500);
            }
        }

        void shellBrowser_ShellItemUpdate(object sender, ShellItemUpdateEventArgs e)
        {
            if (updating)
            {
                if (this.InvokeRequired)
                    Invoke(updateInvoker, sender, e);
                else
                    ShellItemUpdateInvoke(sender, e);
            }
        }

        private void ShellItemUpdateInvoke(object sender, ShellItemUpdateEventArgs e)
        {
            switch (e.UpdateType)
            {
                case ShellItemUpdateType.Created:
                    #region Created
                    {
                        if (e.NewItem.IsFolder)
                        {
                            ShellItem parent = sender as ShellItem;
                            TreeNode parentNode;

                            if (folderView.GetTreeNode(parent, out parentNode))
                            {
                                TreeNode newNode = new TreeNode(
                                    e.NewItem.Text,
                                    e.NewItem.ImageIndex,
                                    e.NewItem.SelectedImageIndex);
                                newNode.Tag = e.NewItem;

                                if (e.NewItem.HasSubfolder)
                                    newNode.Nodes.Add(string.Empty);

                                newNode.Name = newNode.Text;

                                parentNode.Nodes.Add(newNode);
                            }
                        }
                    }
                    #endregion
                    break;

                case ShellItemUpdateType.Deleted:
                    #region Deleted
                    {
                        if (e.OldItem.IsFolder)
                        {
                            ShellItem parent = sender as ShellItem;
                            TreeNode parentNode;

                            if (folderView.GetTreeNode(parent, out parentNode))
                            {
                                parentNode.Nodes.RemoveByKey(e.OldItem.Text);
                            }
                        }
                    }
                    #endregion
                    break;

                case ShellItemUpdateType.Renamed:
                    #region Renamed
                    {
                        if (e.NewItem.IsFolder)
                        {
                            TreeNode node;

                            if (folderView.GetTreeNode(e.NewItem, out node))
                            {
                                node.Text = e.NewItem.Text;
                                node.Name = node.Text;
                                
                                TreeNode parent = node.Parent;
                                parent.Nodes.Remove(node);
                                parent.Nodes.Add(node);
                            }
                        }
                    }
                    #endregion 
                    break;

                case ShellItemUpdateType.IconChange:
                    #region IconChange
                    {
                        if (e.NewItem.IsFolder)
                        {
                            TreeNode node;

                            if (folderView.GetTreeNode(e.NewItem, out node) && node.ImageIndex != e.NewItem.ImageIndex)
                            {
                                node.ImageIndex = e.NewItem.ImageIndex;
                            }
                        }
                    }
                    #endregion
                    break;

                case ShellItemUpdateType.MediaChange:
                    #region MediaChange
                    {
                        TreeNode node;
                        if (folderView.GetTreeNode(e.NewItem, out node))
                        {
                            node.Collapse(true);

                            if (node.Equals(selectedNode) || folderView.IsParentNode(node, selectedNode))
                                folderView.SelectedNode = node.Parent;

                            node.Nodes.Clear();
                            node.ImageIndex = e.NewItem.ImageIndex;

                            if (e.NewItem.HasSubfolder)
                                node.Nodes.Add(string.Empty);
                        }
                    }
                    #endregion
                    break;
            }
        }

        #endregion

        #region Select Path

        /// <summary>
        /// This method is used by PathExists and SelectPath to convert a string (path to a directory)
        /// to another string which is easier to use.
        /// </summary>
        /// <param name="path">The path to a directory to convert</param>
        /// <returns>The converted string</returns>
        private string ConvertPath(string path)
        {
            if (string.IsNullOrEmpty(path))
                return path;

            string newPath = path.Trim();

            if (newPath.StartsWith(
                    string.Format(@"{0}\", ShellBrowser.MyComputerName),
                    false,
                    CultureInfo.InstalledUICulture) && newPath.Length > 12)
                newPath = newPath.Substring(path.IndexOf('\\') + 1);

            if (!newPath.EndsWith(@":\") && newPath.EndsWith(@"\"))
                newPath = newPath.Substring(0, newPath.Length - 1);

            if (newPath.EndsWith(@"\"))
                newPath = newPath.Substring(0, newPath.Length - 1);

            return newPath;
        }

        /// <summary>
        /// This method uses SHGetFileInfo to check whether a path to a directory exists.
        /// </summary>
        /// <param name="path">The path to check</param>
        /// <returns>true if it exists, false otherwise</returns>
        private bool PathExists(string path)
        {
            string realPath = ConvertPath(path);

            if (string.IsNullOrEmpty(realPath))
                return false;
            else if (string.Compare(path, "desktop", true) == 0)
                return true;

            string[] pathParts = realPath.Split('\\');

            for (int i = 0; i < pathParts.Length; i++)
            {
                bool found = false;
                if (ShellBrowser.DesktopItem.SubFolders.Contains(pathParts[i]))
                {
                    pathParts[i] = ShellItem.GetRealPath(
                        ShellBrowser.DesktopItem.SubFolders[pathParts[i]]);

                    found = true;
                }
                else
                {
                    ShellItem myComp =
                        ShellBrowser.DesktopItem.SubFolders[ShellBrowser.MyComputerName];

                    if (myComp.SubFolders.Contains(pathParts[i]))
                    {
                        pathParts[i] = ShellItem.GetRealPath(
                            myComp.SubFolders[pathParts[i]]);

                        found = true;
                    }
                }

                if (!found)
                    break;
            }

            realPath = string.Join("\\", pathParts);

            if (realPath.EndsWith(":"))
                realPath += "\\";

            ShellAPI.SHFILEINFO info = new ShellAPI.SHFILEINFO();
            IntPtr ptr = ShellAPI.SHGetFileInfo(realPath, 0, ref info, ShellAPI.cbFileInfo, ShellAPI.SHGFI.DISPLAYNAME);
            bool exists = (ptr != IntPtr.Zero);

            Marshal.FreeCoTaskMem(ptr);
            return exists;
        }

        /// <summary>
        /// Selects a path from a string, this can be a direct path, or something like 
        /// "My Documents/My Music". It will set the directory as the current directory.
        /// </summary>
        /// <param name="path">The path to select</param>
        /// <returns>The TreeNode of the directory which was selected, this will be null if the directory
        /// doesn't exist</returns>
        public TreeNode SelectPath(string path, bool expandNode)
        {
            if (string.IsNullOrEmpty(path))
                return null;

            if (PathExists(path))
            {
                string converted = ConvertPath(path);
                string[] pathParts = converted.Split('\\');

                TreeNode currentNode = null;

                #region Get Start Node
                // Change .Expand() to function which extends the node without expanding it

                if (string.Compare(pathParts[0], "desktop", true) == 0)
                    currentNode = desktopNode;
                else if (desktopNode.Nodes.ContainsKey(pathParts[0]))
                {
                    currentNode = desktopNode.Nodes[pathParts[0]];
                    ExtendTreeNode(currentNode, false);
                }
                else
                {
                    if (string.Compare(pathParts[0], myCompNode.Text, true) == 0)
                        currentNode = myCompNode;
                    else
                    {
                        if (pathParts[0][pathParts[0].Length - 1] == ':')
                            pathParts[0] += "\\";

                        foreach (TreeNode node in myCompNode.Nodes)
                        {
                            if (string.Compare(
                                    pathParts[0],
                                    ((ShellItem)node.Tag).Path, true) == 0)
                            {
                                currentNode = node;
                                ExtendTreeNode(currentNode, false);
                                break;
                            }
                        }
                    }
                }

                #endregion

                if (currentNode == null)
                {
                    folderView.EndUpdate();
                    return null;
                }

                #region Iterate

                for (int i = 1; i < pathParts.Length; i++)
                {
                    if (pathParts[i][pathParts[i].Length - 1] == ':')
                        pathParts[i] += "\\";

                    bool found = false;
                    foreach (TreeNode child in currentNode.Nodes)
                    {
                        if (string.Compare(pathParts[i], child.Text, true) == 0)
                        {
                            currentNode = child;
                            found = true;
                            break;
                        }
                    }

                    if (!found)
                    {
                        folderView.EndUpdate();
                        return null;
                    }

                    ExtendTreeNode(currentNode, false);
                }

                #endregion

                if (expandNode)
                    currentNode.Expand();

                folderView.SelectedNode = currentNode;

                return currentNode;
            }
            else
                return null;
        }

        /// <summary>
        /// Selects a path from a value from the SpecialFolders enumeration.
        /// </summary>
        /// <param name="specialFolder">The SpecialFolder to select</param>
        /// <returns>The TreeNode of the directory which was selected, this will be null if the directory
        /// doesn't exist</returns>
        public TreeNode SelectPath(SpecialFolders specialFolder, bool expandNode)
        {
            StringBuilder path = new StringBuilder(256);
            IntPtr pidl = IntPtr.Zero;

            if (specialFolder == SpecialFolders.Desktop)
                return SelectPath("Desktop", expandNode);
            else if (ShellAPI.SHGetFolderPath(
                    IntPtr.Zero, (ShellAPI.CSIDL)specialFolder,
                    IntPtr.Zero, ShellAPI.SHGFP.TYPE_CURRENT, path) == ShellAPI.S_OK)
            {
                path.Replace(ShellBrowser.MyDocumentsPath, ShellBrowser.MyDocumentsName);
                return SelectPath(path.ToString(), expandNode);
            }
            else
            {
                #region Get Pidl

                if (specialFolder == SpecialFolders.MyDocuments)
                {
                    uint pchEaten = 0;
                    ShellAPI.SFGAO pdwAttributes = 0;
                    ShellBrowser.DesktopItem.ShellFolder.ParseDisplayName(
                        IntPtr.Zero,
                        IntPtr.Zero,
                        "::{450d8fba-ad25-11d0-98a8-0800361b1103}",
                        ref pchEaten,
                        out pidl,
                        ref pdwAttributes);
                }
                else
                {
                    ShellAPI.SHGetSpecialFolderLocation(
                        IntPtr.Zero,
                        (ShellAPI.CSIDL)specialFolder,
                        out pidl);
                }

                #endregion

                #region Make Path

                if (pidl != IntPtr.Zero)
                {
                    IntPtr strr = Marshal.AllocCoTaskMem(ShellAPI.MAX_PATH * 2 + 4);
                    Marshal.WriteInt32(strr, 0, 0);
                    StringBuilder buf = new StringBuilder(ShellAPI.MAX_PATH);

                    if (ShellBrowser.DesktopItem.ShellFolder.GetDisplayNameOf(
                                    pidl,
                                    ShellAPI.SHGNO.FORADDRESSBAR | ShellAPI.SHGNO.FORPARSING,
                                    strr) == ShellAPI.S_OK)
                    {
                        ShellAPI.StrRetToBuf(strr, pidl, buf, ShellAPI.MAX_PATH);
                    }

                    Marshal.FreeCoTaskMem(pidl);
                    Marshal.FreeCoTaskMem(strr);

                    if (!string.IsNullOrEmpty(buf.ToString()))
                        return SelectPath(buf.ToString(), expandNode);
                    else
                        return null;
                }
                else
                    return null;

                #endregion
            }
        }

        /// <summary>
        /// Selects a path from an existing ShellItem, this ShellItem must be present in the browsers 
        /// ShellBrowser, otherwise it can't be selected.
        /// </summary>
        /// <param name="specialFolder">The ShellItem to select</param>
        /// <returns>The TreeNode of the directory which was selected, this will be null if the directory
        /// doesn't exist</returns>
        public TreeNode SelectPath(ShellItem item, bool expandNode)
        {
            if (item == null)
                return null;

            ShellItem[] path = ShellBrowser.GetPath(item);

            if (path != null)
            {
                TreeNode currentNode = desktopNode;
                for (int i = 1; i < path.Length; i++)
                {
                    ExtendTreeNode(currentNode, false);
                    foreach (TreeNode subNode in currentNode.Nodes)
                    {
                        if (path[i].Equals(subNode.Tag))
                        {
                            currentNode = subNode;
                            break;
                        }
                    }
                }

                if (expandNode)
                    currentNode.Expand();

                folderView.SelectedNode = currentNode;

                return currentNode;
            }
            else
                return null;
        }

        #endregion

        #region Utilities

        /// <summary>
        /// This method will fill a TreeNode with the folders from it's ShellItem
        /// </summary>
        /// <param name="node">The TreeNode to extend</param>
        private bool ExtendTreeNode(TreeNode node, bool overwrite, IntPtr handle)
        {
            if (overwrite || !IsExtended(node))
            {
                ShellItem nodeItem = (ShellItem)node.Tag;
                ShellBrowser.UpdateCondition.ContinueUpdate = false;

                if (nodeItem.Expand(false, true, handle))
                {
                    folderView.BeginUpdate();
                    node.Nodes.Clear();

                    TreeNode[] newNodesArray = new TreeNode[nodeItem.SubFolders.Count];
                    for (int i = 0; i < newNodesArray.Length; i++)
                    {
                        newNodesArray[i] = new TreeNode(
                            System.IO.Path.GetFileName(nodeItem.SubFolders[i].Path),
                            nodeItem.SubFolders[i].ImageIndex,
                            nodeItem.SubFolders[i].SelectedImageIndex);
                        newNodesArray[i].Tag = nodeItem.SubFolders[i];

                        if (nodeItem.SubFolders[i].HasSubfolder)
                            newNodesArray[i].Nodes.Add(string.Empty);

                        newNodesArray[i].Name = newNodesArray[i].Text;
                    }

                    node.Nodes.AddRange(newNodesArray);

                    folderView.EndUpdate();
                    return true;
                }
                else
                    return false;
            }
            else
                return true;
        }

        private bool ExtendTreeNode(TreeNode node, bool overwrite)
        {
            return ExtendTreeNode(node, overwrite, IntPtr.Zero);
        }

        private bool IsExtended(TreeNode node)
        {
            if (node.Nodes.Count == 1 && string.IsNullOrEmpty(node.Nodes[0].Text))
                return false;
            else
                return true;
        }

        #endregion

        #region Properties

        #region Non Browsable

        #region Public

        [Browsable(false)]
        public ShellItem SelectedItem
        {
            get { return selectedItem; }
            set
            {
                if (value != null)
                    SelectPath(value, false);
            }
        }

        [Browsable(false)]
        public TreeNode SelectedNode
        {
            get { return folderView.SelectedNode; }
            set 
            {
                if (value != null)
                    folderView.SelectedNode = value;
            }
        }

        #endregion

        #region Internal

        [Browsable(false)]
        internal FileBrowser.BrowserTreeView FolderView { get { return folderView; } }

        [Browsable(false)]
        internal bool NewItemCreated
        {
            get { return newItemCreated; }
            set { newItemCreated = value; }
        }

        /// <summary>
        /// The Property of selectionChange. When this bool is true the current directory will change when
        /// a TreeNode is selected, otherwise no change is made to the current directory. This is used to
        /// allow dropping on a TreeNode without changing the current directory.
        /// </summary>
        [Browsable(false)]
        internal bool SelectionChange
        {
            get { return selectionChange; }
            set { selectionChange = value; }
        }

        #endregion

        #endregion

        #region Browsable

        [Category("Options"),
         Description("Sets the Initial Directory of the Tree"),
         DefaultValue(SpecialFolders.MyComputer),
         Browsable(true)]
        public SpecialFolders StartUpDirectory
        {
            get { return startupDir; }
            set 
            {
                if (startupDir != value)
                {
                    startupDir = value;
                }
            }
        }

        [Category("Options"),
         Description("Sets the Initial Directory of the Tree when StartUpDirectory is set to \"Other\""),
         DefaultValue(""),
         Browsable(true)]
        public string StartUpDirectoryOther
        {
            get { return otherStartupDir; }
            set 
            {
                if (otherStartupDir != value)
                {
                    otherStartupDir = value;
                }
            }
        }

        [Category("Options"),
         Description("Sets the ShellBrowser for the control, if null the control will create it's own."),
         DefaultValue(null),
         Browsable(true)]
        public ShellBrowser ShellBrowser
        {
            get { return shellBrowser; }
            set
            {
                if (!ShellDll.ShellBrowser.Equals(ShellBrowser, value))
                {
                    if (ShellBrowser != null)
                        ShellBrowser.Browsers.Remove(this);

                    if (handleCreated) FileBrowser_HandleDestroyed(this, new EventArgs());
                    shellBrowser = value;
                    if (handleCreated) FileBrowser_HandleCreated(this, new EventArgs());

                    if (!ShellBrowser.Browsers.Contains(this))
                        ShellBrowser.Browsers.Add(this);
                }
            }
        }

        #endregion

        #endregion

        #region Public

        public bool CreateNewFolder()
        {
            if (selectedItem.IsFileSystem)
            {
                IntPtr newMenuPtr;
                IContextMenu newMenu;

                if (ContextMenuHelper.GetNewContextMenu(selectedItem, out newMenuPtr, out newMenu))
                {
                    lock (ShellBrowser)
                    {
                        NewItemCreated = true;
                    }

                    ContextMenuHelper.InvokeCommand(newMenu, "NewFolder", ShellItem.GetRealPath(selectedItem), new Point(0, 0));

                    Marshal.ReleaseComObject(newMenu);
                    Marshal.Release(newMenuPtr);

                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }

        #endregion

        #region Drag/Drop

        /// <summary>
        /// When an item is being dragged from the browser this method will set the dragStartControl to the
        /// Control from which it is being dragged. And the drop wrappers will also be informed.
        /// </summary>
        void DragWrapper_DragStart(object sender, DragEnterEventArgs e)
        {
            dragStartControl = e.DragStartControl;

            tvDropWrapper.ParentDragItem = e.Parent;
        }

        void DragWrapper_DragEnd(object sender, EventArgs e)
        {
            tvDropWrapper.ParentDragItem = null;
        }

        /// <summary>
        /// When an item is being dropped on the browser while holding the right mouse button, the context
        /// menu should not be showed. This method will take care of that problem.
        /// </summary>
        void DropWrapper_Drop(object sender, DropEventArgs e)
        {
            if (Control.Equals(dragStartControl, e.DragStartControl) && (e.MouseButtons & ShellAPI.MK.RBUTTON) != 0)
            {
                if (Control.Equals(dragStartControl, folderView))
                    tvContextWrapper.SuspendContextMenu = true;
            }

            dragStartControl = null;
        }

        #endregion
    }

    #region Custom EventArgs

    public class ContextMenuMouseHoverEventArgs : EventArgs
    {
        private string info;

        public ContextMenuMouseHoverEventArgs(string info)
        {
            this.info = info;
        }

        // The help info of the contextmenu item
        public string ContextMenuItemInfo { get { return info; } }
    }

    public class SelectedFolderChangedEventArgs : EventArgs
    {        
        private TreeNode node;
        private ShellItem item;

        public SelectedFolderChangedEventArgs(TreeNode node)
        {
            this.node = node;
            item = (ShellItem)node.Tag;
        }

        // The TreeNode of the new current selected directory
        public TreeNode Node { get { return node; } }

        // The ShellItem of the new current selected directory
        public ShellItem Item { get { return item; } }

        // The full path to the new current selected directory
        public string Path { get { return ShellItem.GetRealPath(item); } }
    }

    #endregion
}
