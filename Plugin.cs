using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LethalLogoMod
{

	[BepInPlugin(modGUID, modName, modVersion)]
	public class LethalLogoMod : BaseUnityPlugin
	{
		public const string modGUID = "com.ashk3000.LethalLogoMod";
		public const string modName = "Lethal Logo Mod";
		public const string modVersion = "1.0.0.0";

		public static ConfigEntry<string> imagePath;

		private readonly Harmony harmony = new Harmony(modGUID);

		private void Awake()
		{

			string defaultImagePath = Path.Combine(Paths.ConfigPath, "logo.png");

			imagePath = Config.Bind("File", // section
									"ImagePath", // key
									defaultImagePath, // default
									"Location of the logo. Its best with a 545 by 249 transparent PNG with no antialiasing."); // description
			
			string defaultLogoPath = Path.Combine(Paths.PluginPath, "Ashk3000-LethalLogoMod", "default.png");

			if (LethalLogoMod.imagePath.Value == defaultImagePath && !File.Exists(LethalLogoMod.imagePath.Value) && File.Exists(defaultLogoPath)) // if it is the default ImagePath and there is no image there and we have the default image
			{
				File.Copy(defaultLogoPath, defaultImagePath);
			}

			harmony.PatchAll(typeof(MenuManagerPatch));
		}
	}

	[HarmonyPatch(typeof(MenuManager))]
	class MenuManagerPatch
	{
		[HarmonyPatch("Start")]
		[HarmonyPostfix]
		static void Postfix()
		{
			
			if (GameObject.Find("HeaderImage") != null && File.Exists(LethalLogoMod.imagePath.Value)) // if the HeaderImage exists and the image exists
			{
				Texture2D texture = new Texture2D(545, 249, TextureFormat.RGBA32, false);
				byte[] fileData = File.ReadAllBytes(LethalLogoMod.imagePath.Value);
				ImageConversion.LoadImage(texture, fileData);

				texture.filterMode = FilterMode.Point;

				Sprite sprite = Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(272.5f, 124.5f), 100.0f);

				GameObject.Find("HeaderImage").GetComponent<Image>().sprite = sprite;
			}
		}
	}
}
