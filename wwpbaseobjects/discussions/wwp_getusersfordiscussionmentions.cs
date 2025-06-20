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
namespace GeneXus.Programs.wwpbaseobjects.discussions {
   public class wwp_getusersfordiscussionmentions : GXProcedure
   {
      protected override bool IntegratedSecurityEnabled
      {
         get {
            return true ;
         }

      }

      protected override GAMSecurityLevel IntegratedSecurityLevel
      {
         get {
            return GAMSecurityLevel.SecurityHigh ;
         }

      }

      protected override string ExecutePermissionPrefix
      {
         get {
            return "wwp_getusersfordiscussionmentions_Services_Execute" ;
         }

      }

      public wwp_getusersfordiscussionmentions( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_getusersfordiscussionmentions( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_SearchTxt ,
                           out string aP1_OptionsJson )
      {
         this.AV14SearchTxt = aP0_SearchTxt;
         this.AV13OptionsJson = "" ;
         initialize();
         ExecuteImpl();
         aP1_OptionsJson=this.AV13OptionsJson;
      }

      public string executeUdp( string aP0_SearchTxt )
      {
         execute(aP0_SearchTxt, out aP1_OptionsJson);
         return AV13OptionsJson ;
      }

      public void executeSubmit( string aP0_SearchTxt ,
                                 out string aP1_OptionsJson )
      {
         this.AV14SearchTxt = aP0_SearchTxt;
         this.AV13OptionsJson = "" ;
         SubmitImpl();
         aP1_OptionsJson=this.AV13OptionsJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV12Options = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtWWPSuggestDataItem>( context, "WWPSuggestDataItem", "Comforta_version2");
         AV10MaxOptions = 5;
         AV9CheckDuplicated = false;
         /* Execute user subroutine: 'SEARCH USERS' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( AV12Options.Count < AV10MaxOptions )
         {
            AV9CheckDuplicated = true;
            /* Execute user subroutine: 'SEARCH USERS' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
            if ( AV12Options.Count < AV10MaxOptions )
            {
               AV9CheckDuplicated = true;
               /* Execute user subroutine: 'SEARCH USERS' */
               S111 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
         }
         AV13OptionsJson = AV12Options.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'SEARCH USERS' Routine */
         returnInSub = false;
         lV14SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV14SearchTxt), "%", "");
         lV14SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV14SearchTxt), "%", "");
         /* Using cursor P00402 */
         pr_default.execute(0, new Object[] {lV14SearchTxt});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A114WWPUserExtendedEmail = P00402_A114WWPUserExtendedEmail[0];
            A113WWPUserExtendedFullName = P00402_A113WWPUserExtendedFullName[0];
            A122WWPUserExtendedDeleted = P00402_A122WWPUserExtendedDeleted[0];
            A121WWPUserExtendedName = P00402_A121WWPUserExtendedName[0];
            A112WWPUserExtendedId = P00402_A112WWPUserExtendedId[0];
            A40000WWPUserExtendedPhoto_GXI = P00402_A40000WWPUserExtendedPhoto_GXI[0];
            AV8WWPUserExtendedFullName = (String.IsNullOrEmpty(StringUtil.RTrim( A113WWPUserExtendedFullName)) ? A121WWPUserExtendedName : A113WWPUserExtendedFullName);
            AV11Option = new WorkWithPlus.workwithplus_web.SdtWWPSuggestDataItem(context);
            AV11Option.gxTpr_Id = A112WWPUserExtendedId;
            AV11Option.gxTpr_Displayname = AV8WWPUserExtendedFullName;
            AV11Option.gxTpr_Text.Add(AV8WWPUserExtendedFullName, 0);
            AV11Option.gxTpr_Text.Add(A114WWPUserExtendedEmail, 0);
            AV11Option.gxTpr_Text.Add(A40000WWPUserExtendedPhoto_GXI, 0);
            if ( ! AV9CheckDuplicated || ! StringUtil.Contains( AV12Options.ToJSonString(false), AV11Option.ToJSonString(false, true)) )
            {
               AV12Options.Add(AV11Option, 0);
            }
            if ( AV12Options.Count > AV10MaxOptions )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
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
         AV13OptionsJson = "";
         AV12Options = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtWWPSuggestDataItem>( context, "WWPSuggestDataItem", "Comforta_version2");
         lV14SearchTxt = "";
         P00402_A114WWPUserExtendedEmail = new string[] {""} ;
         P00402_A113WWPUserExtendedFullName = new string[] {""} ;
         P00402_A122WWPUserExtendedDeleted = new bool[] {false} ;
         P00402_A121WWPUserExtendedName = new string[] {""} ;
         P00402_A112WWPUserExtendedId = new string[] {""} ;
         P00402_A40000WWPUserExtendedPhoto_GXI = new string[] {""} ;
         A114WWPUserExtendedEmail = "";
         A113WWPUserExtendedFullName = "";
         A121WWPUserExtendedName = "";
         A112WWPUserExtendedId = "";
         A40000WWPUserExtendedPhoto_GXI = "";
         AV8WWPUserExtendedFullName = "";
         AV11Option = new WorkWithPlus.workwithplus_web.SdtWWPSuggestDataItem(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.discussions.wwp_getusersfordiscussionmentions__default(),
            new Object[][] {
                new Object[] {
               P00402_A114WWPUserExtendedEmail, P00402_A113WWPUserExtendedFullName, P00402_A122WWPUserExtendedDeleted, P00402_A121WWPUserExtendedName, P00402_A112WWPUserExtendedId, P00402_A40000WWPUserExtendedPhoto_GXI
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV10MaxOptions ;
      private string A112WWPUserExtendedId ;
      private bool AV9CheckDuplicated ;
      private bool returnInSub ;
      private bool A122WWPUserExtendedDeleted ;
      private string AV13OptionsJson ;
      private string AV14SearchTxt ;
      private string lV14SearchTxt ;
      private string A114WWPUserExtendedEmail ;
      private string A113WWPUserExtendedFullName ;
      private string A121WWPUserExtendedName ;
      private string A40000WWPUserExtendedPhoto_GXI ;
      private string AV8WWPUserExtendedFullName ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtWWPSuggestDataItem> AV12Options ;
      private IDataStoreProvider pr_default ;
      private string[] P00402_A114WWPUserExtendedEmail ;
      private string[] P00402_A113WWPUserExtendedFullName ;
      private bool[] P00402_A122WWPUserExtendedDeleted ;
      private string[] P00402_A121WWPUserExtendedName ;
      private string[] P00402_A112WWPUserExtendedId ;
      private string[] P00402_A40000WWPUserExtendedPhoto_GXI ;
      private WorkWithPlus.workwithplus_web.SdtWWPSuggestDataItem AV11Option ;
      private string aP1_OptionsJson ;
   }

   public class wwp_getusersfordiscussionmentions__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00402;
          prmP00402 = new Object[] {
          new ParDef("lV14SearchTxt",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00402", "SELECT WWPUserExtendedEmail, WWPUserExtendedFullName, WWPUserExtendedDeleted, WWPUserExtendedName, WWPUserExtendedId, WWPUserExtendedPhoto_GXI FROM WWP_UserExtended WHERE (Not ( WWPUserExtendedDeleted)) AND (WWPUserExtendedFullName like '%' || :lV14SearchTxt or WWPUserExtendedEmail like :lV14SearchTxt) ORDER BY WWPUserExtendedId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00402,100, GxCacheFrequency.OFF ,false,false )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 40);
                ((string[]) buf[5])[0] = rslt.getMultimediaUri(6);
                return;
       }
    }

 }

}
