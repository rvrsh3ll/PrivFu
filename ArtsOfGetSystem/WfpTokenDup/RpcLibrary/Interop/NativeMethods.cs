﻿using System;
using System.Runtime.InteropServices;
using RpcLibrary;

namespace RpcLibrary.Interop
{
    using RPC_STATUS = Int32;

    internal class NativeMethods
    {
        /*
         * rpcrt4.dll
         */
        [DllImport("rpcrt4.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr NdrClientCall3(
            IntPtr /* in MIDL_STUBLESS_PROXY_INFO */ pProxyInfo,
            uint nProcNum,
            IntPtr pReturnValue,
            string pPrinterName,
            out IntPtr pHandle,
            string pDatatype,
            ref DEVMODE_CONTAINER pDevModeContainer,
            int AccessRequired);

        [DllImport("rpcrt4.dll")]
        public static extern RPC_STATUS RpcBindingFree(ref IntPtr Binding);

        [DllImport("rpcrt4.dll", EntryPoint = "RpcBindingFromStringBindingW", CharSet = CharSet.Unicode)]
        public static extern RPC_STATUS RpcBindingFromStringBinding(
            string StringBinding,
            out IntPtr Binding);

        [DllImport("rpcrt4.dll", EntryPoint = "RpcBindingSetAuthInfoW", CharSet = CharSet.Unicode)]
        public static extern RPC_STATUS RpcBindingSetAuthInfo(
            IntPtr Binding,
            string ServerPrincName,
            uint AuthnLevel,
            uint AuthnSvc,
            IntPtr AuthIdentity,
            uint AuthzSvc);

        [DllImport("rpcrt4.dll")]
        public static extern RPC_STATUS RpcBindingSetOption(
            IntPtr hBinding,
            uint option,
            UIntPtr optionValue);

        [DllImport("rpcrt4.dll")]
        public static extern RPC_STATUS RpcEpResolveBinding(IntPtr Binding, IntPtr IfSpec);

        [DllImport("rpcrt4.dll", EntryPoint = "RpcStringBindingComposeW", CharSet = CharSet.Unicode)]
        public static extern RPC_STATUS RpcStringBindingCompose(
            string ObjUuid,
            string ProtSeq,
            string NetworkAddr,
            IntPtr /* string */ Endpoint,
            string Options,
            out string StringBinding);

        [DllImport("rpcrt4.dll", EntryPoint = "RpcStringFreeW", CharSet = CharSet.Unicode)]
        public static extern RPC_STATUS RpcStringFree(in string RpcString);
    }
}