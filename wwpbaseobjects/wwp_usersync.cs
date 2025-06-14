using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs.wwpbaseobjects {
   public class wwp_usersync : GXProcedure
   {
      public wwp_usersync( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_usersync( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_TrnMode ,
                           GeneXus.Programs.genexussecurity.SdtGAMUser aP1_GAMUser ,
                           out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP2_Messages )
      {
         this.AV10TrnMode = aP0_TrnMode;
         this.AV8GAMUser = aP1_GAMUser;
         this.AV9Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         initialize();
         ExecuteImpl();
         aP2_Messages=this.AV9Messages;
      }

      public GXBaseCollection<GeneXus.Utils.SdtMessages_Message> executeUdp( string aP0_TrnMode ,
                                                                             GeneXus.Programs.genexussecurity.SdtGAMUser aP1_GAMUser )
      {
         execute(aP0_TrnMode, aP1_GAMUser, out aP2_Messages);
         return AV9Messages ;
      }

      public void executeSubmit( string aP0_TrnMode ,
                                 GeneXus.Programs.genexussecurity.SdtGAMUser aP1_GAMUser ,
                                 out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP2_Messages )
      {
         this.AV10TrnMode = aP0_TrnMode;
         this.AV8GAMUser = aP1_GAMUser;
         this.AV9Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         SubmitImpl();
         aP2_Messages=this.AV9Messages;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         new WorkWithPlus.workwithplus_webgam.wwp_gamlog(context ).execute(  5,  StringUtil.Format( "TrnMode: %1 - %2, GAMUser: %3", AV10TrnMode, GeneXus.Core.genexus.gxdomaintrnmode.getDescription(context,AV10TrnMode), AV8GAMUser.tojsonstring(), "", "", "", "", "", ""),  AV14Pgmname) ;
         if ( StringUtil.StrCmp(AV10TrnMode, "INS") == 0 )
         {
            AV11WWP_UserExtended = new GeneXus.Programs.wwpbaseobjects.SdtWWP_UserExtended(context);
            AV11WWP_UserExtended.gxTpr_Wwpuserextendedid = AV8GAMUser.gxTpr_Guid;
            AV11WWP_UserExtended.gxTpr_Wwpuserextendedname = StringUtil.RTrim( AV8GAMUser.gxTpr_Name);
            AV11WWP_UserExtended.gxTpr_Wwpuserextendedfullname = StringUtil.RTrim( AV8GAMUser.gxTpr_Firstname)+(String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.RTrim( AV8GAMUser.gxTpr_Firstname)))||String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.RTrim( AV8GAMUser.gxTpr_Lastname))) ? "" : " ")+StringUtil.RTrim( AV8GAMUser.gxTpr_Lastname);
            AV11WWP_UserExtended.gxTpr_Wwpuserextendedemail = ((StringUtil.StrCmp(StringUtil.RTrim( AV8GAMUser.gxTpr_Email), context.GetMessage( "admin", ""))!=0) ? StringUtil.RTrim( AV8GAMUser.gxTpr_Email) : "");
            AV11WWP_UserExtended.gxTpr_Wwpuserextendedphone = StringUtil.RTrim( AV8GAMUser.gxTpr_Phone);
            AV11WWP_UserExtended.gxTpr_Wwpuserextendeddesktopnotif = true;
            AV11WWP_UserExtended.gxTpr_Wwpuserextendedemainotif = true;
            AV11WWP_UserExtended.gxTpr_Wwpuserextendedsmsnotif = true;
            AV11WWP_UserExtended.gxTpr_Wwpuserextendedmobilenotif = true;
            AV11WWP_UserExtended.gxTpr_Wwpuserextendeddeleted = AV8GAMUser.gxTpr_Isdeleted;
            if ( AV8GAMUser.gxTpr_Isdeleted )
            {
               AV11WWP_UserExtended.gxTpr_Wwpuserextendeddeletedin = DateTimeUtil.ServerNow( context, pr_default);
            }
            else
            {
               AV11WWP_UserExtended.gxTv_SdtWWP_UserExtended_Wwpuserextendeddeletedin_SetNull();
            }
            AV11WWP_UserExtended.Save();
            if ( ! AV11WWP_UserExtended.Success() )
            {
               AV9Messages = AV11WWP_UserExtended.GetMessages();
            }
         }
         else if ( StringUtil.StrCmp(AV10TrnMode, "UPD") == 0 )
         {
            AV11WWP_UserExtended.Load(AV8GAMUser.gxTpr_Guid);
            if ( AV11WWP_UserExtended.Fail() )
            {
               AV11WWP_UserExtended = new GeneXus.Programs.wwpbaseobjects.SdtWWP_UserExtended(context);
               AV11WWP_UserExtended.gxTpr_Wwpuserextendedid = AV8GAMUser.gxTpr_Guid;
            }
            AV11WWP_UserExtended.gxTpr_Wwpuserextendedname = StringUtil.RTrim( AV8GAMUser.gxTpr_Name);
            AV11WWP_UserExtended.gxTpr_Wwpuserextendedfullname = StringUtil.RTrim( AV8GAMUser.gxTpr_Firstname)+(String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.RTrim( AV8GAMUser.gxTpr_Firstname)))||String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.RTrim( AV8GAMUser.gxTpr_Lastname))) ? "" : " ")+StringUtil.RTrim( AV8GAMUser.gxTpr_Lastname);
            AV11WWP_UserExtended.gxTpr_Wwpuserextendedemail = ((StringUtil.StrCmp(StringUtil.RTrim( AV8GAMUser.gxTpr_Email), context.GetMessage( "admin", ""))!=0) ? StringUtil.RTrim( AV8GAMUser.gxTpr_Email) : "");
            AV11WWP_UserExtended.gxTpr_Wwpuserextendedphone = StringUtil.RTrim( AV8GAMUser.gxTpr_Phone);
            AV11WWP_UserExtended.Save();
            if ( ! AV11WWP_UserExtended.Success() )
            {
               AV9Messages = AV11WWP_UserExtended.GetMessages();
            }
         }
         else if ( StringUtil.StrCmp(AV10TrnMode, "DLT") == 0 )
         {
            AV11WWP_UserExtended.Load(AV8GAMUser.gxTpr_Guid);
            if ( AV11WWP_UserExtended.Success() )
            {
               AV11WWP_UserExtended.gxTpr_Wwpuserextendeddeleted = true;
               AV11WWP_UserExtended.gxTpr_Wwpuserextendeddeletedin = DateTimeUtil.ServerNow( context, pr_default);
               AV11WWP_UserExtended.Save();
               if ( ! AV11WWP_UserExtended.Success() )
               {
                  AV9Messages = AV11WWP_UserExtended.GetMessages();
               }
            }
            else
            {
               AV9Messages = AV11WWP_UserExtended.GetMessages();
            }
         }
         if ( AV9Messages.Count > 0 )
         {
            new WorkWithPlus.workwithplus_webgam.wwp_gamlog(context ).execute(  20,  StringUtil.Format( "TrnMode: %1 - %2, GAMUser: %3, Messages %4", AV10TrnMode, GeneXus.Core.genexus.gxdomaintrnmode.getDescription(context,AV10TrnMode), AV8GAMUser.tojsonstring(), AV9Messages.ToJSonString(false), "", "", "", "", ""),  AV14Pgmname) ;
         }
         cleanup();
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV9Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV14Pgmname = "";
         AV11WWP_UserExtended = new GeneXus.Programs.wwpbaseobjects.SdtWWP_UserExtended(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.wwp_usersync__default(),
            new Object[][] {
            }
         );
         AV14Pgmname = "WWPBaseObjects.WWP_UserSync";
         /* GeneXus formulas. */
         AV14Pgmname = "WWPBaseObjects.WWP_UserSync";
      }

      private string AV10TrnMode ;
      private string AV14Pgmname ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV8GAMUser ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV9Messages ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWP_UserExtended AV11WWP_UserExtended ;
      private IDataStoreProvider pr_default ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP2_Messages ;
   }

   public class wwp_usersync__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

 }

}
