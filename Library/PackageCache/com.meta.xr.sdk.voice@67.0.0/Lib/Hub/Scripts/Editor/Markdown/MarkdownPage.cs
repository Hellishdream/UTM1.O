﻿/*
 * Copyright (c) Meta Platforms, Inc. and affiliates.
 * All rights reserved.
 *
 * Licensed under the Oculus SDK License Agreement (the "License");
 * you may not use the Oculus SDK except in compliance with the License,
 * which is provided at the time of installation or download, or which
 * otherwise accompanies this software in either electronic or hard copy form.
 *
 * You may obtain a copy of the License at
 *
 * https://developer.oculus.com/licenses/oculussdk/
 *
 * Unless required by applicable law or agreed to in writing, the Oculus SDK
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using Meta.Voice.Hub.Attributes;
using Meta.Voice.Hub.Interfaces;
using UnityEngine;

namespace Meta.Voice.Hub.Markdown
{
    [MetaHubPageScriptableObject]
    public class MarkdownPage : ScriptableObject, IPageInfo
    {
        [SerializeField] private string _displayName;
        [SerializeField] private string _prefix;
        [SerializeField] private MetaHubContext _context;
        [SerializeField] private TextAsset _markdownFile;
        [SerializeField] private int _priority = 0;

        internal TextAsset MarkdownFile => _markdownFile;
        public string Name => _displayName ?? name;
        public string Context => _context.Name;
        public int Priority => _priority;
        public string Prefix => _prefix;
    }
}
