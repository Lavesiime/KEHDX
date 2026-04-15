using SonicRetro.SonLVL.API;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;

namespace KEHDXObjectDefinitions.R5
{
	class VPlatform : ObjectDefinition
	{
		private PropertySpec[] properties = new PropertySpec[4];
		private Sprite[] sprites = new Sprite[6];
		private Sprite[] debug = new Sprite[2];
		
		public override void Init(ObjectData data)
		{
			BitmapBits sheet = LevelData.GetSpriteSheet("R5/Objects.gif");
			
			sprites[0] = new Sprite(sheet.GetSection(1, 51, 32, 32), -16, -16);
			sprites[1] = new Sprite(sprites[0], new Sprite(sheet.GetSection(65, 208, 32, 16), -16, -16));
			
			sprites[2] = new Sprite(sheet.GetSection(34, 51, 64, 32), -32, -16);
			sprites[3] = new Sprite(sprites[2], new Sprite(sheet.GetSection(1, 208, 64, 16), -32, -16));
			
			sprites[4] = new Sprite(sheet.GetSection(1, 84, 96, 32), -48, -16);
			sprites[5] = new Sprite(sprites[4], new Sprite(sheet.GetSection(1, 191, 96, 16), -48, -16));
			
			BitmapBits bitmap = new BitmapBits(2, 97);
			bitmap.DrawLine(6, 0, 0, 0, 96);
			debug[0] = new Sprite(bitmap);
			debug[1] = new Sprite(debug[0], false, true);
			
			properties[0] = new PropertySpec("Start From", typeof(int), "Extended",
				"Which side this platform should start from.", null, new Dictionary<string, int>
				{
					{ "Top", 0 },
					{ "Bottom", 1 }
				},
				(obj) => obj.PropertyValue & 1,
				(obj, value) => obj.PropertyValue = (byte)((obj.PropertyValue & ~1) | (int)value));
			
			properties[1] = new PropertySpec("Modifier", typeof(int), "Extended",
				"Which effects this platform should have.", null, new Dictionary<string, int>
				{
					{ "Normal", 0 },
//					{ "Carry Springs", 2 },
					{ "Conveyor", 4 }
				},
				(obj) => obj.PropertyValue & 6,
				(obj, value) => obj.PropertyValue = (byte)((obj.PropertyValue & ~6) | (int)value));
			
			properties[2] = new PropertySpec("Size", typeof(int), "Extended",
				"How large this platform should be.", null, new Dictionary<string, int>
				{
					{ "Small", 0 },
					{ "Medium", 8 },
					{ "Large", 0x10 }
				},
				(obj) => obj.PropertyValue & 0x18,
				(obj, value) => obj.PropertyValue = (byte)((obj.PropertyValue & ~0x18) | (int)value));
			
			properties[3] = new PropertySpec("Priority", typeof(int), "Extended",
				"Which priority this platform should have.", null, new Dictionary<string, int>
				{
					{ "Normal", 0 },
					{ "XBounds", 0x80 }
				},
				(obj) => obj.PropertyValue & 0x80,
				(obj, value) => obj.PropertyValue = (byte)((obj.PropertyValue & ~0x80) | (int)value));
		}

		public override ReadOnlyCollection<byte> Subtypes
		{
			get { return new ReadOnlyCollection<byte>(new byte[0]); }
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
			get { return sprites[0]; }
		}

		public override Sprite SubtypeImage(byte subtype)
		{
			return sprites[((subtype & 0x18) >> 2) + (((subtype & 6) == 4) ? 1 : 0)];
		}

		public override Sprite GetSprite(ObjectEntry obj)
		{
			return sprites[((obj.PropertyValue & 0x18) >> 2) + (((obj.PropertyValue & 6) == 4) ? 1 : 0)];
		}
		
		public override Sprite GetDebugOverlay(ObjectEntry obj)
		{
			return debug[obj.PropertyValue & 1];
		}
	}
}