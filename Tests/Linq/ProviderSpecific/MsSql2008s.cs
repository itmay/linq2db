﻿using System;

using LinqToDB;

using NUnit.Framework;

namespace Tests.ProviderSpecific
{
	using Model;

	[TestFixture]
	public class MsSql2008 : TestBase
	{
		[Test]
		public void SqlTest([IncludeDataContexts(ProviderName.SqlServer2008)] string context)
		{
			using (var db = new TestDbManager(context))
			using (var rd = db.SetCommand(@"
				SELECT
					DateAdd(Hour, 1, [t].[DateTimeValue]) - [t].[DateTimeValue]
				FROM
					[LinqDataTypes] [t]")
				.ExecuteReader())
			{
				if (rd.Read())
				{
					var value = rd.GetValue(0);
				}
			}
		}
	}
}
