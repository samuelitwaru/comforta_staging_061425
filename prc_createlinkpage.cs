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
   public class prc_createlinkpage : GXProcedure
   {
      public prc_createlinkpage( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_createlinkpage( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_AppVersionId ,
                           string aP1_PageName ,
                           string aP2_Url ,
                           short aP3_WWPFormId ,
                           string aP4_WWPFormReferenceName ,
                           out SdtSDT_AppVersion_PagesItem aP5_PageItem ,
                           out SdtSDT_Error aP6_SDT_Error )
      {
         this.AV8AppVersionId = aP0_AppVersionId;
         this.AV9PageName = aP1_PageName;
         this.AV21Url = aP2_Url;
         this.AV18WWPFormId = aP3_WWPFormId;
         this.AV22WWPFormReferenceName = aP4_WWPFormReferenceName;
         this.AV11PageItem = new SdtSDT_AppVersion_PagesItem(context) ;
         this.AV10SDT_Error = new SdtSDT_Error(context) ;
         initialize();
         ExecuteImpl();
         aP5_PageItem=this.AV11PageItem;
         aP6_SDT_Error=this.AV10SDT_Error;
      }

      public SdtSDT_Error executeUdp( Guid aP0_AppVersionId ,
                                      string aP1_PageName ,
                                      string aP2_Url ,
                                      short aP3_WWPFormId ,
                                      string aP4_WWPFormReferenceName ,
                                      out SdtSDT_AppVersion_PagesItem aP5_PageItem )
      {
         execute(aP0_AppVersionId, aP1_PageName, aP2_Url, aP3_WWPFormId, aP4_WWPFormReferenceName, out aP5_PageItem, out aP6_SDT_Error);
         return AV10SDT_Error ;
      }

      public void executeSubmit( Guid aP0_AppVersionId ,
                                 string aP1_PageName ,
                                 string aP2_Url ,
                                 short aP3_WWPFormId ,
                                 string aP4_WWPFormReferenceName ,
                                 out SdtSDT_AppVersion_PagesItem aP5_PageItem ,
                                 out SdtSDT_Error aP6_SDT_Error )
      {
         this.AV8AppVersionId = aP0_AppVersionId;
         this.AV9PageName = aP1_PageName;
         this.AV21Url = aP2_Url;
         this.AV18WWPFormId = aP3_WWPFormId;
         this.AV22WWPFormReferenceName = aP4_WWPFormReferenceName;
         this.AV11PageItem = new SdtSDT_AppVersion_PagesItem(context) ;
         this.AV10SDT_Error = new SdtSDT_Error(context) ;
         SubmitImpl();
         aP5_PageItem=this.AV11PageItem;
         aP6_SDT_Error=this.AV10SDT_Error;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( ! new prc_isauthenticated(context).executeUdp( ) )
         {
            AV10SDT_Error.gxTpr_Status = context.GetMessage( "Error", "");
            AV10SDT_Error.gxTpr_Message = context.GetMessage( "Not Authenticated", "");
            cleanup();
            if (true) return;
         }
         AV13BC_Trn_AppVersion.Load(AV8AppVersionId);
         AV12BC_Page.gxTpr_Pageid = Guid.NewGuid( );
         AV12BC_Page.gxTpr_Pagename = AV9PageName;
         AV15SDT_LinkPage = new SdtSDT_LinkPage(context);
         if ( ! ( AV18WWPFormId == 0 ) )
         {
            AV15SDT_LinkPage.gxTpr_Wwpformid = AV18WWPFormId;
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV22WWPFormReferenceName ,
                                                 A208WWPFormReferenceName ,
                                                 AV18WWPFormId ,
                                                 A206WWPFormId } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.SHORT
                                                 }
            });
            /* Using cursor P00G72 */
            pr_default.execute(0, new Object[] {AV18WWPFormId, AV22WWPFormReferenceName});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A208WWPFormReferenceName = P00G72_A208WWPFormReferenceName[0];
               A206WWPFormId = P00G72_A206WWPFormId[0];
               A207WWPFormVersionNumber = P00G72_A207WWPFormVersionNumber[0];
               AV19GAMApplication = new GeneXus.Programs.genexussecurity.SdtGAMApplication(context).get();
               AV20baseUrl = AV19GAMApplication.gxTpr_Environment.gxTpr_Url;
               AV15SDT_LinkPage.gxTpr_Url = AV20baseUrl+"utoolboxdynamicform.aspx?WWPFormId="+StringUtil.Trim( StringUtil.Str( (decimal)(AV18WWPFormId), 4, 0))+context.GetMessage( "&WWPDynamicFormMode=DSP&DefaultFormType=&WWPFormType=0&WWPFormReferenceName=", "")+StringUtil.Trim( AV22WWPFormReferenceName);
               AV12BC_Page.gxTpr_Pagetype = "DynamicForm";
               pr_default.readNext(0);
            }
            pr_default.close(0);
         }
         else
         {
            AV15SDT_LinkPage.gxTpr_Url = AV21Url;
            AV12BC_Page.gxTpr_Pagetype = "WebLink";
         }
         AV12BC_Page.gxTpr_Pagestructure = AV15SDT_LinkPage.ToJSonString(false, true);
         AV13BC_Trn_AppVersion.gxTpr_Page.Add(AV12BC_Page, 0);
         AV13BC_Trn_AppVersion.Save();
         if ( AV13BC_Trn_AppVersion.Success() )
         {
            context.CommitDataStores("prc_createlinkpage",pr_default);
            AV11PageItem.FromJSonString(AV12BC_Page.ToJSonString(true, true), null);
            AV11PageItem.gxTpr_Pagelinkstructure = AV15SDT_LinkPage;
         }
         else
         {
            AV25GXV2 = 1;
            AV24GXV1 = AV13BC_Trn_AppVersion.GetMessages();
            while ( AV25GXV2 <= AV24GXV1.Count )
            {
               AV14Message = ((GeneXus.Utils.SdtMessages_Message)AV24GXV1.Item(AV25GXV2));
               AV10SDT_Error.gxTpr_Message = AV14Message.gxTpr_Description;
               AV25GXV2 = (int)(AV25GXV2+1);
            }
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
         AV11PageItem = new SdtSDT_AppVersion_PagesItem(context);
         AV10SDT_Error = new SdtSDT_Error(context);
         AV13BC_Trn_AppVersion = new SdtTrn_AppVersion(context);
         AV12BC_Page = new SdtTrn_AppVersion_Page(context);
         AV15SDT_LinkPage = new SdtSDT_LinkPage(context);
         A208WWPFormReferenceName = "";
         P00G72_A208WWPFormReferenceName = new string[] {""} ;
         P00G72_A206WWPFormId = new short[1] ;
         P00G72_A207WWPFormVersionNumber = new short[1] ;
         AV19GAMApplication = new GeneXus.Programs.genexussecurity.SdtGAMApplication(context);
         AV20baseUrl = "";
         AV24GXV1 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV14Message = new GeneXus.Utils.SdtMessages_Message(context);
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.prc_createlinkpage__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.prc_createlinkpage__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_createlinkpage__default(),
            new Object[][] {
                new Object[] {
               P00G72_A208WWPFormReferenceName, P00G72_A206WWPFormId, P00G72_A207WWPFormVersionNumber
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV18WWPFormId ;
      private short A206WWPFormId ;
      private short A207WWPFormVersionNumber ;
      private int AV25GXV2 ;
      private string AV9PageName ;
      private string AV21Url ;
      private string AV22WWPFormReferenceName ;
      private string A208WWPFormReferenceName ;
      private string AV20baseUrl ;
      private Guid AV8AppVersionId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDT_AppVersion_PagesItem AV11PageItem ;
      private SdtSDT_Error AV10SDT_Error ;
      private SdtTrn_AppVersion AV13BC_Trn_AppVersion ;
      private SdtTrn_AppVersion_Page AV12BC_Page ;
      private SdtSDT_LinkPage AV15SDT_LinkPage ;
      private IDataStoreProvider pr_default ;
      private string[] P00G72_A208WWPFormReferenceName ;
      private short[] P00G72_A206WWPFormId ;
      private short[] P00G72_A207WWPFormVersionNumber ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplication AV19GAMApplication ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV24GXV1 ;
      private GeneXus.Utils.SdtMessages_Message AV14Message ;
      private SdtSDT_AppVersion_PagesItem aP5_PageItem ;
      private SdtSDT_Error aP6_SDT_Error ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class prc_createlinkpage__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class prc_createlinkpage__gam : DataStoreHelperBase, IDataStoreHelper
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

public class prc_createlinkpage__default : DataStoreHelperBase, IDataStoreHelper
{
   protected Object[] conditional_P00G72( IGxContext context ,
                                          string AV22WWPFormReferenceName ,
                                          string A208WWPFormReferenceName ,
                                          short AV18WWPFormId ,
                                          short A206WWPFormId )
   {
      System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
      string scmdbuf;
      short[] GXv_int1 = new short[2];
      Object[] GXv_Object2 = new Object[2];
      scmdbuf = "SELECT WWPFormReferenceName, WWPFormId, WWPFormVersionNumber FROM WWP_Form";
      AddWhere(sWhereString, "(WWPFormId = :AV18WWPFormId)");
      if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22WWPFormReferenceName)) )
      {
         AddWhere(sWhereString, "(WWPFormReferenceName = ( :AV22WWPFormReferenceName))");
      }
      else
      {
         GXv_int1[1] = 1;
      }
      scmdbuf += sWhereString;
      scmdbuf += " ORDER BY WWPFormId";
      GXv_Object2[0] = scmdbuf;
      GXv_Object2[1] = GXv_int1;
      return GXv_Object2 ;
   }

   public override Object [] getDynamicStatement( int cursor ,
                                                  IGxContext context ,
                                                  Object [] dynConstraints )
   {
      switch ( cursor )
      {
            case 0 :
                  return conditional_P00G72(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (short)dynConstraints[3] );
      }
      return base.getDynamicStatement(cursor, context, dynConstraints);
   }

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
       Object[] prmP00G72;
       prmP00G72 = new Object[] {
       new ParDef("AV18WWPFormId",GXType.Int16,4,0) ,
       new ParDef("AV22WWPFormReferenceName",GXType.VarChar,100,0)
       };
       def= new CursorDef[] {
           new CursorDef("P00G72", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00G72,100, GxCacheFrequency.OFF ,false,false )
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
             ((short[]) buf[1])[0] = rslt.getShort(2);
             ((short[]) buf[2])[0] = rslt.getShort(3);
             return;
    }
 }

}

}
