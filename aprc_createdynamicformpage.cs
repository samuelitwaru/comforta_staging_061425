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
   public class aprc_createdynamicformpage : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new aprc_createdynamicformpage().MainImpl(args); ;
      }

      public int executeCmdLine( string[] args )
      {
         return ExecuteCmdLine(args); ;
      }

      protected override int ExecuteCmdLine( string[] args )
      {
         context.StatusMessage( "Command line using complex types not supported." );
         return GX.GXRuntime.ExitCode ;
      }

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

      public aprc_createdynamicformpage( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aprc_createdynamicformpage( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_FormId ,
                           string aP1_PageName ,
                           out SdtSDT_Page aP2_SDT_Page ,
                           out SdtSDT_Error aP3_Error )
      {
         this.AV23FormId = aP0_FormId;
         this.AV15PageName = aP1_PageName;
         this.AV18SDT_Page = new SdtSDT_Page(context) ;
         this.AV22Error = new SdtSDT_Error(context) ;
         initialize();
         ExecuteImpl();
         aP2_SDT_Page=this.AV18SDT_Page;
         aP3_Error=this.AV22Error;
      }

      public SdtSDT_Error executeUdp( Guid aP0_FormId ,
                                      string aP1_PageName ,
                                      out SdtSDT_Page aP2_SDT_Page )
      {
         execute(aP0_FormId, aP1_PageName, out aP2_SDT_Page, out aP3_Error);
         return AV22Error ;
      }

      public void executeSubmit( Guid aP0_FormId ,
                                 string aP1_PageName ,
                                 out SdtSDT_Page aP2_SDT_Page ,
                                 out SdtSDT_Error aP3_Error )
      {
         this.AV23FormId = aP0_FormId;
         this.AV15PageName = aP1_PageName;
         this.AV18SDT_Page = new SdtSDT_Page(context) ;
         this.AV22Error = new SdtSDT_Error(context) ;
         SubmitImpl();
         aP2_SDT_Page=this.AV18SDT_Page;
         aP3_Error=this.AV22Error;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( ! new prc_isauthenticated(context).executeUdp( ) )
         {
            AV22Error.gxTpr_Status = context.GetMessage( "Error", "");
            AV22Error.gxTpr_Message = context.GetMessage( "Not Authenticated", "");
         }
         else
         {
            /* Using cursor P00AP2 */
            pr_default.execute(0, new Object[] {AV23FormId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A366LocationDynamicFormId = P00AP2_A366LocationDynamicFormId[0];
               A11OrganisationId = P00AP2_A11OrganisationId[0];
               A29LocationId = P00AP2_A29LocationId[0];
               AV8BC_Trn_Page = new SdtTrn_Page(context);
               AV8BC_Trn_Page.gxTpr_Trn_pageid = AV23FormId;
               AV8BC_Trn_Page.gxTpr_Trn_pagename = AV15PageName;
               AV8BC_Trn_Page.gxTpr_Pageispublished = false;
               GXt_guid1 = Guid.Empty;
               new prc_getuserlocationid(context ).execute( out  GXt_guid1) ;
               AV8BC_Trn_Page.gxTpr_Locationid = GXt_guid1;
               GXt_guid1 = Guid.Empty;
               new prc_getuserorganisationid(context ).execute( out  GXt_guid1) ;
               AV8BC_Trn_Page.gxTpr_Organisationid = GXt_guid1;
               AV8BC_Trn_Page.gxTpr_Pagegjshtml = "";
               AV8BC_Trn_Page.gxTpr_Pagegjsjson = "";
               AV8BC_Trn_Page.gxTpr_Pageiscontentpage = false;
               AV8BC_Trn_Page.gxTpr_Pageisdynamicform = true;
               AV8BC_Trn_Page.gxTv_SdtTrn_Page_Pagechildren_SetNull();
               AV8BC_Trn_Page.gxTv_SdtTrn_Page_Productserviceid_SetNull();
               AV8BC_Trn_Page.Save();
               if ( AV8BC_Trn_Page.Success() )
               {
                  context.CommitDataStores("prc_createdynamicformpage",pr_default);
               }
               AV18SDT_Page.gxTpr_Pageid = AV8BC_Trn_Page.gxTpr_Trn_pageid;
               AV18SDT_Page.gxTpr_Pagename = AV8BC_Trn_Page.gxTpr_Trn_pagename;
               pr_default.readNext(0);
            }
            pr_default.close(0);
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
         AV18SDT_Page = new SdtSDT_Page(context);
         AV22Error = new SdtSDT_Error(context);
         P00AP2_A366LocationDynamicFormId = new Guid[] {Guid.Empty} ;
         P00AP2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00AP2_A29LocationId = new Guid[] {Guid.Empty} ;
         A366LocationDynamicFormId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         AV8BC_Trn_Page = new SdtTrn_Page(context);
         GXt_guid1 = Guid.Empty;
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.aprc_createdynamicformpage__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.aprc_createdynamicformpage__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aprc_createdynamicformpage__default(),
            new Object[][] {
                new Object[] {
               P00AP2_A366LocationDynamicFormId, P00AP2_A11OrganisationId, P00AP2_A29LocationId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private string AV15PageName ;
      private Guid AV23FormId ;
      private Guid A366LocationDynamicFormId ;
      private Guid A11OrganisationId ;
      private Guid A29LocationId ;
      private Guid GXt_guid1 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDT_Page AV18SDT_Page ;
      private SdtSDT_Error AV22Error ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00AP2_A366LocationDynamicFormId ;
      private Guid[] P00AP2_A11OrganisationId ;
      private Guid[] P00AP2_A29LocationId ;
      private SdtTrn_Page AV8BC_Trn_Page ;
      private SdtSDT_Page aP2_SDT_Page ;
      private SdtSDT_Error aP3_Error ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class aprc_createdynamicformpage__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class aprc_createdynamicformpage__gam : DataStoreHelperBase, IDataStoreHelper
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

public class aprc_createdynamicformpage__default : DataStoreHelperBase, IDataStoreHelper
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
       Object[] prmP00AP2;
       prmP00AP2 = new Object[] {
       new ParDef("AV23FormId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("P00AP2", "SELECT LocationDynamicFormId, OrganisationId, LocationId FROM Trn_LocationDynamicForm WHERE LocationDynamicFormId = :AV23FormId ORDER BY LocationDynamicFormId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AP2,100, GxCacheFrequency.OFF ,true,false )
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
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             return;
    }
 }

}

}
