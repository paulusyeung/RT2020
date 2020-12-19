using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RT2020.Helper
{
    public class EnumHelper
    {
        public enum EditMode
        {
            None,
            Add,
            Edit,
            Delete
        }

        /// <summary>
        /// Status
        /// </summary>
        public enum Status
        {
            /// <summary>
            /// The item is changed its status to inactive, means the item was deleted and no longer be used in the system.
            /// </summary>
            Inactive = -2,
            /// <summary>
            /// Default status, mostly be used in Transaction.
            /// </summary>
            Draft = 0,
            /// <summary>
            /// The item is active, and can be used where it would be.
            /// </summary>
            Active = 1,
            /// <summary>
            /// The item is modified, after export, the status would be changed to [Active].Mostly be used in master code mantainance.
            /// </summary>
            Modified = 2,
            /// <summary>
            /// The item is deleted.
            /// </summary>
            Deleted = -1
        }

        /// <summary>
        /// Product Price Type
        /// </summary>
        public enum ProductPriceType
        {
            /// <summary>
            /// Original Retail Price
            /// </summary>
            ORIPRC,
            /// <summary>
            /// Retail Price /Basic Price
            /// </summary>
            BASPRC,
            /// <summary>
            /// WholeSale Price
            /// </summary>
            WHLPRC,
            /// <summary>
            /// Vendor Price
            /// </summary>
            VPRC
        }

        /// <summary>
        /// Transaction Type
        /// </summary>
        public enum TxType
        {
            /// <summary>
            /// Cash Sales
            /// </summary>
            CAS,

            /// <summary>
            /// Cash Sales Return 
            /// </summary>
            CRT,

            /// <summary>
            /// Cash Sales Void 
            /// </summary>
            VOD,

            /// <summary>
            /// Wholesales Sales
            /// </summary>
            SAL,

            /// <summary>
            /// Normal Invoice 
            /// </summary>
            NML,

            /// <summary>
            /// Balance Invoice
            /// </summary>
            BAL,

            /// <summary>
            /// Wholesales Sales Return
            /// </summary>
            SRT,

            /// <summary>
            /// Credit Note Invoice
            /// </summary>
            ICN,

            /// <summary>
            /// Receiving via CASH
            /// </summary>
            CAP,

            /// <summary>
            /// Receiving via PO
            /// </summary>
            REC,

            /// <summary>
            /// Reject To Supplier
            /// </summary>
            REJ,

            /// <summary>
            /// Transfer IN/OUT
            /// </summary>
            TXF,

            /// <summary>
            /// Transfer IN 
            /// </summary>
            TXI,

            /// <summary>
            /// Transfer OUT
            /// </summary>
            TXO,

            /// <summary>
            /// Transfer IN 
            /// </summary>
            TRI,

            /// <summary>
            /// Transfer OUT
            /// </summary>
            TRO,

            /// <summary>
            /// Picking Note
            /// </summary>
            PNQ,

            /// <summary>
            /// Adjustment
            /// </summary>
            ADJ,

            /// <summary>
            /// Deposit Sales
            /// </summary>
            DEP,

            /// <summary>
            /// Deposit Sales Return
            /// </summary>
            DRT,

            /// <summary>
            /// Suspend Sales
            /// </summary>
            SUP,

            /// <summary>
            /// Stock Take
            /// </summary>
            STK,

            /// <summary>
            /// Requisition
            /// </summary>
            REQ,

            /// <summary>
            /// Assembling 
            /// </summary>
            ASM,

            /// <summary>
            /// Disassembling
            /// </summary>
            DSM,

            /// <summary>
            /// Replenishment
            /// </summary>
            RPL,

            /// <summary>
            /// Price Management
            /// </summary>
            PMS,

            /// <summary>
            /// Price Change
            /// </summary>
            PMC
        }

        /// <summary>
        /// Purchase Order Transaction Type
        /// </summary>
        public enum POType
        {
            /// <summary>
            /// FPO - Foreign Purchase Order (外國購貨單)
            /// </summary>
            FPO,

            /// <summary>
            /// LPO - Local Purchase Order (本地購貨單)
            /// </summary>
            LPO,

            /// <summary>
            /// OPO - Other Purchase Order (其他購貨單)
            /// </summary>
            OPO
        }

        /// <summary>
        /// Layout for displaying list
        /// </summary>
        public enum Layout
        {
            /// <summary>
            /// Card View
            /// </summary>
            CardView,

            /// <summary>
            /// Thumbnails
            /// </summary>
            Thumbnails,

            /// <summary>
            /// List View
            /// </summary>
            ListView
        }

        /// <summary>
        /// Permission of accessing functions
        /// </summary>
        [Flags]
        public enum Permission
        {
            /// <summary>
            /// read permission
            /// </summary>
            Read = 0x001A,
            /// <summary>
            /// write permission
            /// </summary>
            Write = 0x002B,
            /// <summary>
            /// posting permission
            /// </summary>
            Posting = 0x003C,
            /// <summary>
            /// erase permission
            /// </summary>
            Delete = 0x004D,
            /// <summary>
            /// Modify permission (Read, Write, Posting)
            /// </summary>
            Modify = Permission.Read | Permission.Write | Permission.Posting,
            /// <summary>
            /// All permission (Read, Write, Posting, Delete)
            /// </summary>
            All = Permission.Modify | Permission.Delete
        }

        public enum UserType { Staff, Customer, Supplier, Member }
    }
}