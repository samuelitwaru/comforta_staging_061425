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
   public class prc_createpage : GXProcedure
   {
      public prc_createpage( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_createpage( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_PageName ,
                           string aP1_PageJsonContent ,
                           ref string aP2_Response ,
                           out SdtSDT_Error aP3_error )
      {
         this.AV16PageName = aP0_PageName;
         this.AV13PageJsonContent = aP1_PageJsonContent;
         this.AV17Response = aP2_Response;
         this.AV21error = new SdtSDT_Error(context) ;
         initialize();
         ExecuteImpl();
         aP2_Response=this.AV17Response;
         aP3_error=this.AV21error;
      }

      public SdtSDT_Error executeUdp( string aP0_PageName ,
                                      string aP1_PageJsonContent ,
                                      ref string aP2_Response )
      {
         execute(aP0_PageName, aP1_PageJsonContent, ref aP2_Response, out aP3_error);
         return AV21error ;
      }

      public void executeSubmit( string aP0_PageName ,
                                 string aP1_PageJsonContent ,
                                 ref string aP2_Response ,
                                 out SdtSDT_Error aP3_error )
      {
         this.AV16PageName = aP0_PageName;
         this.AV13PageJsonContent = aP1_PageJsonContent;
         this.AV17Response = aP2_Response;
         this.AV21error = new SdtSDT_Error(context) ;
         SubmitImpl();
         aP2_Response=this.AV17Response;
         aP3_error=this.AV21error;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( ! new prc_isauthenticated(context).executeUdp( ) )
         {
            AV21error.gxTpr_Status = context.GetMessage( "Error", "");
            AV21error.gxTpr_Message = context.GetMessage( "Not Authenticated", "");
         }
         else
         {
            AV8BC_Trn_Page = new SdtTrn_Page(context);
            AV8BC_Trn_Page.gxTpr_Trn_pagename = AV16PageName;
            AV8BC_Trn_Page.gxTpr_Pageispublished = false;
            GXt_guid1 = Guid.Empty;
            new prc_getuserlocationid(context ).execute( out  GXt_guid1) ;
            AV8BC_Trn_Page.gxTpr_Locationid = GXt_guid1;
            GXt_guid1 = Guid.Empty;
            new prc_getuserorganisationid(context ).execute( out  GXt_guid1) ;
            AV8BC_Trn_Page.gxTpr_Organisationid = GXt_guid1;
            AV8BC_Trn_Page.gxTpr_Pagegjshtml = "";
            AV8BC_Trn_Page.gxTpr_Pagegjsjson = AV13PageJsonContent;
            AV8BC_Trn_Page.gxTpr_Pageiscontentpage = false;
            AV8BC_Trn_Page.gxTv_SdtTrn_Page_Pagechildren_SetNull();
            AV8BC_Trn_Page.gxTv_SdtTrn_Page_Productserviceid_SetNull();
            AV8BC_Trn_Page.Save();
            if ( AV8BC_Trn_Page.Success() )
            {
               context.CommitDataStores("prc_createpage",pr_default);
            }
            else
            {
               AV24GXV2 = 1;
               AV23GXV1 = AV8BC_Trn_Page.GetMessages();
               while ( AV24GXV2 <= AV23GXV1.Count )
               {
                  AV9Message = ((GeneXus.Utils.SdtMessages_Message)AV23GXV1.Item(AV24GXV2));
                  new prc_logtofile(context ).execute(  AV9Message.gxTpr_Description) ;
                  AV24GXV2 = (int)(AV24GXV2+1);
               }
            }
            AV17Response = AV8BC_Trn_Page.ToJSonString(true, true);
            new prc_logtofile(context ).execute(  AV17Response) ;
            cleanup();
            if (true) return;
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
         AV21error = new SdtSDT_Error(context);
         AV8BC_Trn_Page = new SdtTrn_Page(context);
         GXt_guid1 = Guid.Empty;
         AV23GXV1 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV9Message = new GeneXus.Utils.SdtMessages_Message(context);
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.prc_createpage__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.prc_createpage__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_createpage__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private int AV24GXV2 ;
      private string AV13PageJsonContent ;
      private string AV17Response ;
      private string AV16PageName ;
      private Guid GXt_guid1 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private string aP2_Response ;
      private SdtSDT_Error AV21error ;
      private SdtTrn_Page AV8BC_Trn_Page ;
      private IDataStoreProvider pr_default ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV23GXV1 ;
      private GeneXus.Utils.SdtMessages_Message AV9Message ;
      private SdtSDT_Error aP3_error ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class prc_createpage__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class prc_createpage__gam : DataStoreHelperBase, IDataStoreHelper
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

public class prc_createpage__default : DataStoreHelperBase, IDataStoreHelper
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
