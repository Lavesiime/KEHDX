using SonicRetro.SonLVL.API;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;

namespace KEHDXObjectDefinitions.R5
{
	class ForegroundPiece : ObjectDefinition
	{
		private PropertySpec[] properties = new PropertySpec[1];
		private Sprite[] sprites = new Sprite[2];
		private Sprite[] debug = new Sprite[2];
		
		public override void Init(ObjectData data)
		{
			BitmapBits sheet = LevelData.GetSpriteSheet("R5/Objects.gif");
			sprites[0] = new Sprite(sheet.GetSection(1, 225, 52, 8), -26, -4);
			sprites[1] = new Sprite(sheet.GetSection(150, 144, 8, 52), -4, -26);
			
			for (int i = 0; i < sprites.Length; i++)
			{
				sprites[i] = new Sprite(sprites[i], new Sprite(sprites[i], true, true));
				
				Rectangle bounds = sprites[i].Bounds;
				BitmapBits overlay = new BitmapBits(bounds.Size);
				overlay.DrawRectangle(6, 0, 0, bounds.Width - 1, bounds.Height - 1); // LevelData.ColorWhite
				debug[i] = new Sprite(overlay, bounds.X, bounds.Y);
			}
			
			properties[0] = new PropertySpec("Frame", typeof(int), "Extended",
				"Which sprite this object should display.", null, new Dictionary<string, int>
				{
					{ "Horizontal", 0 },
					{ "Vertical", 1 },
				},
				(obj) => (int)obj.PropertyValue,
				(obj, value) => obj.PropertyValue = (byte)((int)value));
		}
		
		public override ReadOnlyCollection<byte> Subtypes
		{
			get { return new ReadOnlyCollection<byte>(new byte[] {0, 1}); }
		}
		
		public override PropertySpec[] CustomProperties
		{
			get { return properties; }
		}
		
		public override string SubtypeName(byte subtype)
		{
			return properties[0].Enumeration.GetKey(subtype);
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
		
		/*
		public override Sprite GetDebugOverlay(ObjectEntry obj)
		{
			return debug[obj.PropertyValue];
		}
		*/
	}
}