using SonicRetro.SonLVL.API;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;

namespace KEHDXObjectDefinitions.Title
{
	class MainMenu : ObjectDefinition
	{
		private Sprite[] sprites = new Sprite[9];
		private PropertySpec[] properties = new PropertySpec[1];

		public override void Init(ObjectData data)
		{
			BitmapBits sheet = LevelData.GetSpriteSheet("Menu/Menu.gif");
			sprites[0] = new Sprite(sheet.GetSection(128, 0, 284, 113), -142, -3);  // Knuckles' Emerald Hunt, DX!
			sprites[1] = new Sprite(sheet.GetSection(128, 113, 159, 17), -80, -10); // Single Player
			sprites[2] = new Sprite(sheet.GetSection(128, 131, 159, 16), -80, -10); // Competition
			sprites[3] = new Sprite(sheet.GetSection(412, 0, 95, 16), -80, -10);    // Options
			sprites[4] = new Sprite(sheet.GetSection(412, 17, 100, 16), -80, -10);  // Credits
			sprites[5] = new Sprite(sheet.GetSection(271, 165, 23, 22), -109, -11); // Knuckles cursor B
			sprites[6] = new Sprite(sheet.GetSection(295, 165, 24, 22), -109, -11); // Knuckles cursor A
			sprites[7] = new Sprite(sheet.GetSection(138, 250, 304, 10), -152, -5); // Website link
			sprites[8] = new Sprite(sheet.GetSection(136, 261, 90, 48), 52, 62); // DX
			
			properties[0] = new PropertySpec("ID", typeof(int), "Extended",
				"What this object is.", null, new Dictionary<string, int>
				{
					{ "Master", 0 },
					{ "Single Player Button", 1 },
					{ "Competition Button", 2 },
					{ "Options Button", 3 },
					{ "Credits Button", 4 },
					{ "Knuckles Cursor", 5 },
					{ "Website Link", 7 },
					{ "DX", 8 }
				},
				(obj) => (int)obj.PropertyValue,
				(obj, value) => obj.PropertyValue = (byte)((int)value));
		}

		public override ReadOnlyCollection<byte> Subtypes
		{
			get { return new ReadOnlyCollection<byte>(new byte[] { 0, 1, 2, 3, 4, 5, 7, 8 }); }
		}

		public override byte DefaultSubtype
		{
			get { return 0; }
		}

		public override PropertySpec[] CustomProperties
		{
			get { return properties; }
		}

		public override string SubtypeName(byte subtype)
		{
			switch (subtype)
			{
				case 0: return "Master";
				case 1: return "Single Player Button";
				case 2: return "Competition Button";
				case 3: return "Options Button";
				case 4: return "Credits Button";
				case 5: return "Knuckles Cursor";
				case 7: return "Website Link";
				case 8: return "DX";
				default: return "Unknown";
			}
		}

		public override Sprite Image
		{
			get { return sprites[0]; }
		}

		public override Sprite SubtypeImage(byte subtype)
		{
			return sprites[subtype];
		}

		public override Sprite GetSprite(ObjectEntry obj)
		{
			return sprites[obj.PropertyValue];
		}
	}
}