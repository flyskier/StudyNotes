A guid function that works in all php versions:

<?php
function guid(){
    if (function_exists('com_create_guid')){
        return com_create_guid();
    }else{
        mt_srand((double)microtime()*10000);//optional for php 4.2.0 and up.
        $charid = strtoupper(md5(uniqid(rand(), true)));
        $hyphen = chr(45);// "-"
        $uuid = chr(123)// "{"
                .substr($charid, 0, 8).$hyphen
                .substr($charid, 8, 4).$hyphen
                .substr($charid,12, 4).$hyphen
                .substr($charid,16, 4).$hyphen
                .substr($charid,20,12)
                .chr(125);// "}"
        return $uuid;
    }
}

function get_guid()
{
    $guid="";
    if (function_exists('com_create_guid'))
    {
        $guid=substr(com_create_guid(),1,-1);
    }
    //linux
    else
    {
        mt_srand((double)microtime()*10000);//optional for php 4.2.0 and up.
            $charid = strtoupper(md5(uniqid(rand(), true)));
            $hyphen = chr(45);// "-"
            $uuid = chr(123)// "{"
                    .substr($charid, 0, 8).$hyphen
                    .substr($charid, 8, 4).$hyphen
                    .substr($charid,12, 4).$hyphen
                    .substr($charid,16, 4).$hyphen
                    .substr($charid,20,12)
                    .chr(125);// "}"
            $guid=substr($uuid,1,-1);
       // return $uuid;
    }
    return $guid;
}
//$socketstr = array(
//   '参数1'=>值,
//   '参数2'=>值,
 //   );
//$socketstr='';
function interact_server($SERVER,$PORT,$sockstr,$addr,$data_type,$timeout = 10)
{
    try{
        //get method
        if($data_type=='get'){
            $options = array(  
            'http' => array(  
                'timeout' => $timeout,// 超时时间（单位:s）  
                'content' => $sockstr,  

            ));  
        }
        //post
        else{
            $sockstr = json_encode($sockstr);
            $options = array(  
                'http' => array(  
                'method' => 'POST',  
                'header' => 'Content-type:application/json;charset=utf-8',  
                'content' => $sockstr,  
                'timeout' => $timeout // 超时时间（单位:s）  
                )  
            );  
        }

        $url = "http://".$SERVER.":".$PORT."/".$addr;
       // var_dump($url);

        $context = stream_context_create($options);
        $result = file_get_contents($url, false, $context); 
        return $result; 
    }
    catch(Exception $e){
        return 0;
    }
}


	/*删除指定目录下的文件，不删除目录文件夹*/
	function delFile($dirName,$delSelf=false){
		if(file_exists($dirName) && $handle = opendir($dirName)){
			while(false !==($item = readdir( $handle))){
				if($item != '.' && $item != '..'){
					if(file_exists($dirName.'/'.$item) && is_dir($dirName.'/'.$item)){
						delFile($dirName.'/'.$item);
					}else{
						if(!unlink($dirName.'/'.$item)){
							return false;
						}
					}
				}
			}
			closedir($handle);
			if($delSelf){
				if(!rmdir($dirName)){
					return false;
				}
			}
		}else{
			return false;
		}
		return true;
	}
?>
