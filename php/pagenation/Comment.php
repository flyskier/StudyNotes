<!DOCTYPE html>
<html>
<head lang="en">
	<meta http-equiv="Content-Type" charset="utf-8"/>
	<title>PHP Ajax提交数据</title>
</head>
<body>
	<lable>用户名：</lable><input type="text" name="userName" size="35" id="username"/>
	<br/><br/>
	<lable>评论区：</lable><textarea rows="10" cols="10" name="comment" id="content"></textarea>
	<br/><br/><br/>
	<input type="submit" value="提交" id="submit"/>
	<br/><br/>
	<?php
       $info=file_get_contents('comment.txt');
       //var_dump(isset($info));
       //var_dump($info!="﻿");
       if(isset($info)&&$info!="﻿")
       {
			$commentLsit=unserialize($info);
			//print_r($_GET);
			var_dump($commentLsit);
			$totalCount=count($commentLsit);
			$page=isset($_GET['page'])?intval($_GET['page']):1;
			$limit=isset($_GET['limit'])?intval($_GET['limit']):3;
			$totalPage=ceil($totalCount/$limit);

			if($page<1)
			{
				$page=1;
			}
			if($page>$totalPage)
			{
				$page=$totalPage;
			}
			$from=($page-1)*$limit;
			for ($i=$from; $i <$from+$limit ; $i++) {
				if(isset($commentLsit[$i]))
				{ 
					echo '用户名：'.$commentLsit[$i]['username'].'<br>评论内容：'.$commentLsit[$i]['content'].'<br><br>';
				}
				else{
					break;
				}
			}
			for ($i=1; $i <=$totalPage ; $i++) { 
				echo"<a href='comment.php?page=$i&limit=$limit'>$i</a>  ";
			}
		}
	?>
	<script src="../jquery-1.11.1.min.js"></script>
	<script type="text/javascript">
		$('#submit').on('click',function(){
			var data1={
				'username':$('#username').val(),
				'content':$('#content').val()
			};
			$.ajax({
				type:'POST',
				url:'addComment.php',
				datatype:'json',
				data:data1,
				success:function(data){   
					alert(data);
					alert(data.code);//访问属性a 
					alert(data['code']);//访问属性a
					 if(!data.code)
					 {
					 	window.location.reload();
					 }
				}

			});
		});
	</script>
</body>
</html>
