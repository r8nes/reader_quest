﻿using System.Threading.Tasks;
using ChooseReader.Service;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace ChooseReader.Structure.AssetManagment
{
    public interface IAssetProvider : IService
    {
        /// <summary>
        ///  Instantiate object without position.
        /// </summary>
        /// <param name="path">Asset path direction</param>
        /// <returns>New object</returns>
        GameObject Instantiate(string path);

        /// <summary>
        ///  Instantiate object with given position.
        /// </summary>
        /// <param name="path">Asset path direction</param>
        /// <param name="point">Current location</param>
        /// <returns>New object</returns>
        GameObject Instantiate(string path, Vector2 point);
    }
}