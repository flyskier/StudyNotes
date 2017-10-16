<?php

$userName=$_POST["username"];
$content=$_POST["content"];
if($userName==''||$content==''){
	// $data['data']=array('code'=>1,'msg'=>'出错了');
	// echo json_encode($data);
	echo json_encode(array('code'=>1,'msg'=>'ERROR'));
}
else
{
	$comment=array('username'=>$userName,'content'=>$content);
	$filePath='comment.txt';
	//file_get_contents() 函数是用来将文件的内容读入到一个字符串中的首选方法
	//unserialize反序列化；unserialize (string $str )$str 序列化后的字符串。
	$commentList=unserialize(file_get_contents($filePath));
	if(is_array($commentList))
	{
		//array_unshift — 在数组开头插入一个或多个单元
		array_unshift($commentList, $comment);
	}
	else{
		$commentList=$comment;
	}
	$commentFile=fopen($filePath, 'w');
	fwrite($commentFile, serialize($commentList));
	fclose($commentFile);
	// $data['data']=array('code'=>0,'msg'=>"评论成功");
	// echo json_encode($data);
	echo json_encode(array('code'=>0,'msg'=>'SUCCESS'));	
}

