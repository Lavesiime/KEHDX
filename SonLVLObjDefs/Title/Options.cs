using SonicRetro.SonLVL.API;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;

namespace KEHDXObjectDefinitions.Title
{
	class Options : ObjectDefinition
	{
		private Sprite[] sprites = new Sprite[6];
		private PropertySpec[] properties = new PropertySpec[1];

		public override void Init(ObjectData data)
		{
			BitmapBits sheet = LevelData.GetSpriteSheet("Menu/Menu.gif");
			sprites[0] = new Sprite(sheet.GetSection(162, 151, 32, 24), -16, -12); // sound test icon (can't think of much better)
			
			BitmapBits bitmap = new BitmapBits(282, 42);
			bitmap.DrawRectangle(1, 2, 2, 279, 39); // Black shadow
			bitmap.DrawRectangle(15, 0, 0, 279, 39); // Yellow rectangle
			
			Sprite sprite = new Sprite(bitmap, -(279/2), 0);
			
			string[,] text = new string[,]
			{
				{"*@@PLAYER SELECT@@*", "KNUCKLES"},
				{"*@@RADAR@@*", "@@ON@@"},
				{"*@@SOUND TEST@@*", "NOT AVAILABLE"},
				{"*@@MUSIC SWITCH@@*", "NOT AVAILABLE"},
				{"*@@RADAR SPRITES@@*", "NEW"},
			};
			
			for (int i = 1; i < 6; i++)
			{
				sprites[i] = DrawText(sprite, sheet, 0, 9, text[i-1,0]);
				sprites[i] = DrawText(sprites[i], sheet, 0, 25, text[i-1,1]);
			}
			
			properties[0] = new PropertySpec("ID", typeof(int), "Extended",
				"What this object is.", null, new Dictionary<string, int>
				{
					{ "Master", 0 },
					{ "Player Select", 1 },
					{ "Radar", 2 },
					{ "Sound Test", 3 },
					{ "Music Switch", 4 },
					{ "Radar Sprites", 5 }
				},
				(obj) => (int)obj.PropertyValue,
				(obj, value) => obj.PropertyValue = (byte)((int)value));
		}

		private Sprite DrawText(Sprite sprite, BitmapBits fontSheet, int x, int y, string text)
		{
			Sprite frame = new Sprite();
			for (int i = 0; i < text.Length; i++)
			{
				frame = new Sprite(frame, new Sprite(fontSheet.GetSection((text[i] & 15) << 3, ((text[i] >> 4) << 3), 8, 8), i << 3, 0));
			}
			
			frame.Offset(x - (text.Length << 2), y);
			
			return new Sprite(sprite, frame);
		}
		
		public override ReadOnlyCollection<byte> Subtypes
		{
			get { return new ReadOnlyCollection<byte>(new byte[] { 0, 1, 2, 3, 4, 5 }); }
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
				case 1: return "Player Select";
				case 2: return "Radar";
				case 3: return "Sound Test";
				case 4: return "Music Switch";
				case 5: return "Radar Sprites";
				default: return "Unknown";
			}
		}

		public override Sprite Image
		{
			get { return sprites[1]; }
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