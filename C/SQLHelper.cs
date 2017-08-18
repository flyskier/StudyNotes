
<appSettings>
<add key="ConnectionString" value="Data Source=服务器地址;database=数据库名;Integrated Security=false;uid=数据库用户名;pwd=密码" />
</appSettings>

 public readonly string constr =  ConfigurationManager.AppSettings["ConnectionString"]
 #region private方法
        /// <summary>
        /// 为执行命令准备参数
        /// </summary>
        /// <param name="cmd">SqlCommand 命令</param>
        /// <param name="conn">已经存在的数据库连接</param>
        /// <param name="trans">数据库事物处理</param>
        /// <param name="cmdType">SqlCommand命令类型 (存储过程， T-SQL语句等)</param>
        /// <param name="cmdText">Command text，T-SQL语句 例如 Select * from table</param>
        /// <param name="cmdParms">返回带参数的命令</param>
        private void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, CommandType cmdType, string cmdText, SqlParameter[] cmdParms)
        {
            //判断数据库连接状态
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            //判断是否需要事物处理
            if (trans != null)
                cmd.Transaction = trans;
            cmd.CommandType = cmdType;
            if (cmdParms != null)
            {
                cmd.Parameters.AddRange(cmdParms);
                // foreach (SqlParameter parm in cmdParms)
                //    cmd.Parameters.Add(parm);
            }

        }
        #endregion

        #region ExecteNonQuery方法
        /// <summary>
        ///执行一个不需要返回值的SqlCommand命令
        /// </summary>
        /// <param name="cmdType">SqlCommand命令类型 (存储过程， T-SQL语句等)</param>
        /// <param name="cmdText">存储过程的名字或者 T-SQL 语句</param>
        /// <param name="commandParameters">以数组形式提供SqlCommand命令中用到的参数列表</param>
        /// <returns>此SqlCommand命令执行后影响的行数</returns>
        private int ExecteNonQuery(CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            using (SqlConnection conn = new SqlConnection(constr))
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                int val = cmd.ExecuteNonQuery();                
                //清空SqlCommand中的参数列表
                cmd.Parameters.Clear();
                return val;
            }
        }

        /// <summary>
        ///SqlCommand命令执行后影响的行数(存储过程专用)
        /// </summary>
        /// <param name="spName">存储过程的名字</param>
        /// <param name="commandParameters">以数组形式提供SqlCommand命令中用到的参数列表</param>
        /// <returns>SqlCommand命令执行后影响的行数</returns>
        public int ExecteNonQueryForProcedure(string spName, params SqlParameter[] commandParameters)
        {
            return ExecteNonQuery(CommandType.StoredProcedure, spName, commandParameters);
        }

        /// <summary>
        ///SqlCommand命令执行后影响的行数(Sql语句专用)
        /// </summary>
        /// <param name="cmdText">T_Sql语句</param>
        /// <param name="commandParameters">以数组形式提供SqlCommand命令中用到的参数列表</param>
        /// <returns>SqlCommand命令执行后影响的行数</returns>
        public int ExecteNonQueryForSqlText(string cmdText, params SqlParameter[] commandParameters)
        {
            return ExecteNonQuery(CommandType.Text, cmdText, commandParameters);
        }

        #endregion

        #region GetDataTable方法
        /// <summary>
        /// 获取执行命令后返回的DataTable
        /// </summary>
        /// <param name="cmdTye">SqlCommand命令类型</param>
        /// <param name="cmdText">存储过程的名字或者 T-SQL 语句</param>
        /// <param name="commandParameters">以数组形式提供SqlCommand命令中用到的参数列表</param>
        /// <returns>返回一个表(DataTable)表示查询得到的数据集</returns>
        private DataTable ExecuteDataTable(CommandType cmdTye, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(constr))
            {
                PrepareCommand(cmd, conn, null, cmdTye, cmdText, commandParameters);
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;
                adapter.Fill(dt);
            }
            return dt;
        }


        /// <summary>
        /// 获取执行命令后返回的DataTable（存储过程专用）
        /// </summary>
        /// <param name="spName">存储过程的名字或者 T-SQL 语句</param>
        /// <param name="commandParameters">以数组形式提供SqlCommand命令中用到的参数列表</param>
        /// <returns></returns>
        public DataTable ExecuteDataTableForProcedure(string spName, params SqlParameter[] commandParameters)
        {
            return ExecuteDataTable(CommandType.StoredProcedure, spName, commandParameters);
        }

        /// <summary>
        /// 获取执行命令后返回的DataTable（Sql语句专用）
        /// </summary>
        /// <param name="cmdText"> T-SQL 语句</param>
        /// <param name="commandParameters">以数组形式提供SqlCommand命令中用到的参数列表</param>
        /// <returns></returns>
        public DataTable ExecuteDataTableForSqlText(string cmdText, params SqlParameter[] commandParameters)
        {
            return ExecuteDataTable(CommandType.Text, cmdText, commandParameters);
        }
        #endregion

        #region ExecuteScalar方法
        /// <summary>
        ///  获取第一行的第一列
        /// </summary>
        /// <param name="cmdType">SqlCommand命令类型 (存储过程， T-SQL语句等)</param>
        /// <param name="cmdText">存储过程的名字或者 T-SQL 语句</param>
        /// <param name="commandParameters">以数组形式提供SqlCommand命令中用到的参数列表</param>
        /// <returns></returns>
        private object ExecuteScalar(CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            using (SqlConnection con = new SqlConnection(constr))
            {
                PrepareCommand(cmd, con, null, cmdType, cmdText, commandParameters);
                object val = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                return val;
            }
        }
        /// <summary>
        /// 获取第一行的第一列（存储过程专用）
        /// </summary>
        /// <param name="spName">存储过程的名字</param>
        /// <param name="commandParameters">以数组形式提供SqlCommand命令中用到的参数列表</param>
        /// <returns></returns>
        public object ExecuteScalarForProcedure(string spName, params SqlParameter[] commandParameters)
        {
            return ExecuteScalar(CommandType.StoredProcedure, spName, commandParameters);
        }

        /// <summary>
        /// 获取第一行的第一列（T_Sql语句专用)
        /// </summary>
        /// <param name="cmdText">者 T-SQL 语句</param>
        /// <param name="commandParameters">以数组形式提供SqlCommand命令中用到的参数列表</param>
        /// <returns></returns>
        public object ExecuteScalarForSqlText(string cmdText, params SqlParameter[] commandParameters)
        {
            return ExecuteScalar(CommandType.Text, cmdText, commandParameters);
        }
        #endregion

        #region ExecuteTransaction 方法
        /// <summary>
        /// ExecuteTransaction执行一组SQL语句
        /// </summary>
        /// <param name="sqlAndPara">SQL语句和参数的键值对集合</param>
        /// <param name="earlyTermination">事务中有数据不满足要求是否提前终止事务</param>
        /// <returns></returns>
        public bool ExecuteTransaction(Dictionary<string, List<SqlParameter[]>> sqlAndPara, bool earlyTermination)
        {
            SqlCommand cmd = new SqlCommand();
            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();
                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        if (sqlAndPara != null)
                        {
                            bool mark = true;//标记值，记录是否有操作失败的
                            foreach (KeyValuePair<string, List<SqlParameter[]>> kvplist in sqlAndPara)
                            {
                                string cmdText = kvplist.Key;//取SQL语句
                                SqlParameter[] commandParameters = null;
                                if (kvplist.Value.Count > 0)
                                {
                                    foreach (var kvp in kvplist.Value)
                                    {
                                        if (kvp != null)//添加参数
                                            commandParameters = kvp;
                                        PrepareCommand(cmd, conn, transaction, CommandType.Text, cmdText, commandParameters);
                                        int val = cmd.ExecuteNonQuery();
                                        //清空SqlCommand中的参数列表
                                        cmd.Parameters.Clear();
                                        if (earlyTermination)
                                        {
                                            if (val <= 0)
                                            {
                                                mark = false;
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                            if (!mark)//如果有某一条执行失败，就回滚
                            {
                                transaction.Rollback(); //事务回滚
                                return false;
                            }
                            else
                            {
                                transaction.Commit();   //事务提交
                                return true;
                            }
                        }
                        else
                            return false;
                    }
                    catch(Exception ex)
                    {
                        transaction.Rollback(); //事务回滚
                        return false;
                    }
                    finally
                    {
                        transaction.Dispose();
                    }
                }
            }
        }

        public bool ExecuteInsertDocTransaction(string docinfosql, SqlParameter[] paras,string indexessql)
        {
            SqlCommand cmd = new SqlCommand();
            int flag = 0;
            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();
                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        cmd.Connection = conn;
                        cmd.Transaction = transaction;

                        cmd.CommandText = docinfosql;
                        cmd.Parameters.AddRange(paras);
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = indexessql;
                        cmd.Parameters.Clear();
                        cmd.ExecuteNonQuery();

                        transaction.Commit();   //事务提交
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback(); //事务回滚
                        SQLHelper.WriteLog(ex.Message + ex.StackTrace);
                        return false;
                    }
                    finally
                    {
                        transaction.Dispose();
                    }                    
                }   
                return true;
            }
        }
        #endregion

        #endregion
