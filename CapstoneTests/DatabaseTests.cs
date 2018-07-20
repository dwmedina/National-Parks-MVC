using System;
using System.Data.SqlClient;
using System.IO;
using System.Transactions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Capstone.Tests
{
	[TestClass]
	public class DatabaseTests
	{
		public const string ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=NPGeek;Integrated Security=True";
		private TransactionScope transaction;

		[TestInitialize]
		public void SetupData()
		{
			transaction = new TransactionScope();

			string sql = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "DBTests.sql"));

			using(SqlConnection 
		}
	}
}
