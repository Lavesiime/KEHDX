using SonicRetro.SonLVL.API;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;

namespace KEHDXObjectDefinitions.Title
{
	class StageSelect : ObjectDefinition
	{
		private Sprite[] sprites = new Sprite[30];
		private PropertySpec[] properties = new PropertySpec[3];

		public override void Init(ObjectData data)
		{
			BitmapBits sheet = LevelData.GetSpriteSheet("Menu/Menu.gif");
			// BitmapBits iconsSheet = LevelData.GetSpriteSheet("Menu/Icons.gif");
			
			Sprite[] frames = new Sprite[30];
			
			sprites[0] = frames[0] = new Sprite(sheet.GetSection(128, 185, 142, 7), -71, 0); // "Select a Stage"
			frames[1] = new Sprite(sheet.GetSection(104, 17, 8, 7), 156, 43); // rank placeholder
			frames[2] = new Sprite(sheet.GetSection(82, 0, 30, 7), 116, 19); // time
			frames[3] = new Sprite(sheet.GetSection(0, 8, 45, 7), -125, 25); // score
			frames[4] = new Sprite(sheet.GetSection(46, 8, 45, 7), -125, 41); // rings
			frames[5] = new Sprite(sheet.GetSection(0, 184, 85, 7), 39, 7); // play count
			frames[6] = new Sprite(sheet.GetSection(10, 15, 37, 7), 39, 19); // time
			frames[7] = new Sprite(sheet.GetSection(10, 143, 53, 7), 39, 31); // deaths
			frames[8] = new Sprite(sheet.GetSection(91, 8, 37, 7), 39, 43); // rank
			frames[9] = new Sprite(sheet.GetSection(162, 151, 32, 24), -161, 16); // icon
			
			Sprite[] numbers = new Sprite[10];
			
			// Numbers
			numbers[0] = new Sprite(sheet.GetSection(0, 25, 8, 7), 0, 0);
			numbers[1] = new Sprite(sheet.GetSection(8, 25, 8, 7), 0, 0);
			numbers[2] = new Sprite(sheet.GetSection(16, 25, 8, 7), 0, 0);
			numbers[3] = new Sprite(sheet.GetSection(24, 25, 8, 7), 0, 0);
			numbers[4] = new Sprite(sheet.GetSection(32, 25, 8, 7), 0, 0);
			numbers[5] = new Sprite(sheet.GetSection(40, 25, 8, 7), 0, 0);
			numbers[6] = new Sprite(sheet.GetSection(48, 25, 8, 7), 0, 0);
			numbers[7] = new Sprite(sheet.GetSection(56, 25, 8, 7), 0, 0);
			numbers[8] = new Sprite(sheet.GetSection(64, 25, 8, 7), 0, 0);
			numbers[9] = new Sprite(sheet.GetSection(72, 25, 8, 7), 0, 0);
			
			Random random = new Random();
			
			BitmapBits bitmap = new BitmapBits(339, 58);
			bitmap.DrawRectangle(1, 2, 2, 336, 55); // Black shadow
			bitmap.DrawRectangle(15, 0, 0, 336, 55); // Yellow rectangle
			
			Sprite sprite = new Sprite(bitmap, -168, 0);
			
			for (int j = 1; j <= 9; j++)
				sprite = new Sprite(sprite, frames[j]);
			
			for (int i = 1; i < 24; i++)
			{
				// Name
				Sprite frame = new Sprite(sprite, new Sprite(sheet.GetSection(0, 192 + ((i-1) * 7), 135, 7), -125, 9));
				
				// i think it's fun to populate the entries with random numbers lol
				frame = DrawNumbers(frame, numbers, 3, 25, random.Next(0, 999999), 6, 8, false); // Score
				frame = DrawNumbers(frame, numbers, 3, 41, random.Next(0, 999), 3, 8, false); // Rings
				
				frame = DrawNumbers(frame, numbers, 156, 7, random.Next(0, 100), 3, 8, false); // Play Count
				
				frame = DrawNumbers(frame, numbers, 156, 19, random.Next(0, 100), 2, 8, true); // Time - ms
				frame = DrawNumbers(frame, numbers, 156 - 27, 19, random.Next(0, 60), 2, 8, true); // Time - sec
				frame = DrawNumbers(frame, numbers, 156 - 50, 19, random.Next(0, 10), 2, 8, false); // Time - min
				
				frame = DrawNumbers(frame, numbers, 156, 31, random.Next(0, 100), 3, 8, false); // Deaths
				
				sprites[i] = frame;
			}
			
			properties[0] = new PropertySpec("ID", typeof(int), "Extended",
				"What this object is.", null, new Dictionary<string, int>
				{
					{ "Emerald Hill", 0 },
					{ "Chemical Plant", 1 },
					{ "Aquatic Ruin", 2 },
					{ "Casino Night", 3 },
					{ "Hill Top", 4 },
					{ "Mystic Cave", 5 },
					{ "Oil Ocean", 6 },
					{ "Metropolis", 7 },
					{ "Wing Fortress", 8 },
					{ "Hidden Palace", 9 },
					{ "Green Hill", 10 },
					{ "Marble", 11 },
					{ "Spring Yard", 12 },
					{ "Labyrinth", 13 },
					{ "Star Light", 14 },
					{ "Scrap Brain", 15 },
					{ "Palmtree Panic", 16 },
					{ "Collision Chaos", 17 },
					{ "Tidal Tempest", 18 },
					{ "Quartz Quadrant", 19 },
					{ "Wacky Workbench", 20 },
					{ "Stardust Speedway", 21 },
					{ "Metallic Madness", 22 },
					{ "Master", 255 }
				},
				(obj) => (int)obj.PropertyValue,
				(obj, value) => obj.PropertyValue = (byte)((int)value));
			
			properties[1] = new PropertySpec("List Pos", typeof(int), "Extended",
				"Only used with buttons.", null,
				(obj) => ((V4ObjectEntry)obj).Value0,
				(obj, value) => ((V4ObjectEntry)obj).Value0 = ((int)value));
			
			properties[2] = new PropertySpec("Active List", typeof(int), "Extended",
				"Only used with buttons.", null, new Dictionary<string, int>
				{
					{ "Presentation Stages", 0 },
					{ "Regular Stages", 1 },
					{ "Special Stages", 2 },
					{ "Bonus Stages", 3 }
				},
				(obj) => ((V4ObjectEntry)obj).Value1,
				(obj, value) => ((V4ObjectEntry)obj).Value1 = ((int)value));
		}

		private Sprite DrawNumbers(Sprite sprite, Sprite[] numbers, int x, int y, int value, int digitCount, int spacing, bool showAllDigits)
		{
			// there's def a better way to do this, but this works fine enough
			
			int i = 10;
			if (showAllDigits)
			{
				while (digitCount > 0)
				{
					int frame = (value % i) / (i / 10);
					sprite = new Sprite(sprite, (new Sprite(numbers[frame], x, y)));
					
					x -= spacing;
					i *= 10;
					digitCount--;
				}
			}
			else {
				int extra = 10;
				if (value > 0) extra *= value;
				while (digitCount > 0)
				{
					if (extra >= i) {
						int frame = (value % i) / (i / 10);
						sprite = new Sprite(sprite, (new Sprite(numbers[frame], x, y)));
					}
					
					x -= spacing;
					i *= 10;
					digitCount--;
				}
			}
			
			return sprite;
		}
		
		public override ReadOnlyCollection<byte> Subtypes
		{
			get { return new ReadOnlyCollection<byte>(new List<byte>()); }
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
			return null;
		}

		public override Sprite Image
		{
			get { return sprites[1]; }
		}

		public override Sprite SubtypeImage(byte subtype)
		{
			return sprites[(subtype == 255) ? 0 : subtype+1];
		}

		public override Sprite GetSprite(ObjectEntry obj)
		{
			return sprites[(obj.PropertyValue == 255) ? 0 : obj.PropertyValue+1];
		}
	}
}