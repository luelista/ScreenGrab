
### Download #######

To download the most recent version, visit the wiki:

http://screengrab.teamwiki.de


### A screenshot is worth a thousand words #######

![Picture of ScreenGrab 6.13](http://screengrab.teamwiki.de/docs/img/screengrab-und-collage.png)

### Image uploading ########

ScreenGrab can upload your screenshots to various online services:

 * Dropme.de
 * Imgur.com
 * Imageshack.com
 * Your own server (Mediacrush API)

#### Upload to your own server #########

WebDAV and FTP upload is planned, but not implemented yet. But you can set up a Mediacrush compatible API endpoint -- this is quite easy:

Upload the .htaccess and upload.php (see below) to your webspace. 
Let's say it is available as ```https://example.org/images/upload.php```
To test if everything works, open ```https://example.org/images/api/upload/file``` in your browser. You should see the message "No file was uploaded!".

Please **make sure the web server has write permissions** in that folder. You could do this with one of the following commands, run in said folder:
> good way, try this first: **setfacl -m group:www-data:rwx .**    
> works always, but might be less secure: **chmod 0777 .**

To use it in ScreenGrab you have to put ```https://example.org/images``` into the "Server" text box in the upload options.

If you're interested, see the [implementation of this upload method](https://github.com/max-weller/ScreenGrab/blob/master/Screengrab5.4/Uploads/UploadMediacrush.vb#L33).

###### .htaccess
```apacheconf
RewriteEngine On
RewriteRule ^api/upload/file /upload.php
# Use the following line to prevent directory list
Options -Indexes
```

###### upload.php
```php
<?php

$hash = substr(md5(time()+mt_rand(1,999999999)),1,20);

$uploaddir = './';
$ext = pathinfo($_FILES['file']['name'], PATHINFO_EXTENSION);
if ($ext != "png" && $ext != "jpg" && $ext != "gif" && $ext != "webp") $ext = "jpg";
$uploadfile = $uploaddir . $hash . "." . $ext;

if (move_uploaded_file($_FILES['file']['tmp_name'], $uploadfile)) {
    echo json_encode(array("x-status" => "200", "hash" => $hash));
} else {
    echo "No file was uploaded!\n";
}

?>
```


### Copyright ############

Copyright (c) 2010-2015 Maximilian Weller
https://max.weller.io

