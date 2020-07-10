using System.Collections.Generic;
using System.IO;
using System.Text;

using NoName.Framework.Core.Config.Declarations;
using NoName.Framework.Core.Config.Declarations.Processors;

namespace NoName.Framework.Core.Config.Implements
{
	public class ConfigTextMemoryStreamProcessor<TC, TO> : IConfigTextMemoryStreamProcessor<TC, TO>
		where TO : IConfig where TC : IConfigBuilder<TO>, new()
	{
		private readonly TC _configBuilder;

		public ConfigTextMemoryStreamProcessor()
		{
			this._configBuilder = this.CreateConfigBuilder();
		}

		public TC CreateConfigBuilder()
		{
			return new TC();
		}

		public TO Process(MemoryStream stream)
		{
			var data = new Dictionary<string, object>();
			var reader = new StreamReader(stream);
			var keyBuilder = new StringBuilder();
			var valueBuilder = new StringBuilder();
			var line = string.Empty;
			while (!reader.EndOfStream)
			{
				var keyReadOver = false;
				var nextLine = false;

				line = reader.ReadLine();
				keyBuilder.Clear();
				valueBuilder.Clear();

				foreach (var ch in line)
				{
					switch (ch)
					{
						case '\'':
							if (keyBuilder.Length != 0 && valueBuilder.Length == 0)
							{
								// TODO: 添加Exception
							}

							nextLine = true;
							break;
						case '=':
							if (keyBuilder.Length == 0)
							{
								// TODO: 添加Exception
							}

							if (valueBuilder.Length != 0)
							{
								// TODO: 添加Exception
							}

							keyReadOver = true;
							continue;
						case ' ':
							if (keyBuilder.Length != 0)
							{
								keyReadOver = true;
							}

							if (valueBuilder.Length != 0)
							{
								nextLine = true;
							}

							continue;
					}

					if (nextLine)
					{
						if (keyBuilder.Length != 0 && valueBuilder.Length != 0)
						{
							if (data.ContainsKey(keyBuilder.ToString()))
							{
								// TODO: 添加Exception
							}
							else
							{
								data.Add(keyBuilder.ToString(), valueBuilder.ToString());
							}
						}

						break;
					}

					if (!keyReadOver)
					{
						keyBuilder.Append(ch);
					}
					else
					{
						valueBuilder.Append(ch);
					}
				}
			}

			return this._configBuilder.Build(data);
		}
	}
}