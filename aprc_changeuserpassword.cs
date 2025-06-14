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
namespace GeneXus.Programs {
   public class aprc_changeuserpassword : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new aprc_changeuserpassword().MainImpl(args); ;
      }

      public int executeCmdLine( string[] args )
      {
         return ExecuteCmdLine(args); ;
      }

      protected override int ExecuteCmdLine( string[] args )
      {
         string aP0_userGUID = new string(' ',0)  ;
         string aP1_password = new string(' ',0)  ;
         string aP2_passwordNew = new string(' ',0)  ;
         string aP3_response = new string(' ',0)  ;
         if ( 0 < args.Length )
         {
            aP0_userGUID=((string)(args[0]));
         }
         else
         {
            aP0_userGUID="";
         }
         if ( 1 < args.Length )
         {
            aP1_password=((string)(args[1]));
         }
         else
         {
            aP1_password="";
         }
         if ( 2 < args.Length )
         {
            aP2_passwordNew=((string)(args[2]));
         }
         else
         {
            aP2_passwordNew="";
         }
         if ( 3 < args.Length )
         {
            aP3_response=((string)(args[3]));
         }
         else
         {
            aP3_response="";
         }
         execute(aP0_userGUID, aP1_password, aP2_passwordNew, out aP3_response);
         return GX.GXRuntime.ExitCode ;
      }

      public aprc_changeuserpassword( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aprc_changeuserpassword( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_userGUID ,
                           string aP1_password ,
                           string aP2_passwordNew ,
                           out string aP3_response )
      {
         this.AV14userGUID = aP0_userGUID;
         this.AV11password = aP1_password;
         this.AV12passwordNew = aP2_passwordNew;
         this.AV13response = "" ;
         initialize();
         ExecuteImpl();
         aP3_response=this.AV13response;
      }

      public string executeUdp( string aP0_userGUID ,
                                string aP1_password ,
                                string aP2_passwordNew )
      {
         execute(aP0_userGUID, aP1_password, aP2_passwordNew, out aP3_response);
         return AV13response ;
      }

      public void executeSubmit( string aP0_userGUID ,
                                 string aP1_password ,
                                 string aP2_passwordNew ,
                                 out string aP3_response )
      {
         this.AV14userGUID = aP0_userGUID;
         this.AV11password = aP1_password;
         this.AV12passwordNew = aP2_passwordNew;
         this.AV13response = "" ;
         SubmitImpl();
         aP3_response=this.AV13response;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV10GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getuserbyguid(AV14userGUID, out  AV9GAMErrorCollection);
         if ( AV10GAMUser.changepassword(AV11password, AV12passwordNew, out  AV9GAMErrorCollection) )
         {
            if ( AV9GAMErrorCollection.Count == 0 )
            {
               context.CommitDataStores("prc_changeuserpassword",pr_default);
               AV16result = new SdtSDT_ChangeYourPassword(context);
               AV16result.gxTpr_Success_message = context.GetMessage( "Password changed successfully", "");
            }
            else
            {
               AV16result = new SdtSDT_ChangeYourPassword(context);
               AV16result.gxTpr_Error.gxTpr_Code = StringUtil.Trim( StringUtil.Str( (decimal)(((GeneXus.Programs.genexussecurity.SdtGAMError)AV9GAMErrorCollection.Item(1)).gxTpr_Code), 12, 0));
               AV16result.gxTpr_Error.gxTpr_Message = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV9GAMErrorCollection.Item(1)).gxTpr_Message;
            }
         }
         else
         {
            AV16result = new SdtSDT_ChangeYourPassword(context);
            AV16result.gxTpr_Error.gxTpr_Code = StringUtil.Trim( StringUtil.Str( (decimal)(((GeneXus.Programs.genexussecurity.SdtGAMError)AV9GAMErrorCollection.Item(1)).gxTpr_Code), 12, 0));
            AV16result.gxTpr_Error.gxTpr_Message = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV9GAMErrorCollection.Item(1)).gxTpr_Message;
         }
         AV13response = AV16result.ToJSonString(false, true);
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
         AV13response = "";
         AV10GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV9GAMErrorCollection = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV16result = new SdtSDT_ChangeYourPassword(context);
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.aprc_changeuserpassword__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.aprc_changeuserpassword__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aprc_changeuserpassword__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private string AV13response ;
      private string AV14userGUID ;
      private string AV11password ;
      private string AV12passwordNew ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV10GAMUser ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV9GAMErrorCollection ;
      private IDataStoreProvider pr_default ;
      private SdtSDT_ChangeYourPassword AV16result ;
      private string aP3_response ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class aprc_changeuserpassword__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

    public override string getDataStoreName( )
    {
       return "DATASTORE1";
    }

 }

 public class aprc_changeuserpassword__gam : DataStoreHelperBase, IDataStoreHelper
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

  public override string getDataStoreName( )
  {
     return "GAM";
  }

}

public class aprc_changeuserpassword__default : DataStoreHelperBase, IDataStoreHelper
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
