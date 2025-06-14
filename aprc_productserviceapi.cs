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
   public class aprc_productserviceapi : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new aprc_productserviceapi().MainImpl(args); ;
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

      public aprc_productserviceapi( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aprc_productserviceapi( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_ProductServiceId ,
                           out SdtSDT_ProductService aP1_SDT_ProductService ,
                           out SdtSDT_Error aP2_Error )
      {
         this.AV8ProductServiceId = aP0_ProductServiceId;
         this.AV9SDT_ProductService = new SdtSDT_ProductService(context) ;
         this.AV19Error = new SdtSDT_Error(context) ;
         initialize();
         ExecuteImpl();
         aP1_SDT_ProductService=this.AV9SDT_ProductService;
         aP2_Error=this.AV19Error;
      }

      public SdtSDT_Error executeUdp( Guid aP0_ProductServiceId ,
                                      out SdtSDT_ProductService aP1_SDT_ProductService )
      {
         execute(aP0_ProductServiceId, out aP1_SDT_ProductService, out aP2_Error);
         return AV19Error ;
      }

      public void executeSubmit( Guid aP0_ProductServiceId ,
                                 out SdtSDT_ProductService aP1_SDT_ProductService ,
                                 out SdtSDT_Error aP2_Error )
      {
         this.AV8ProductServiceId = aP0_ProductServiceId;
         this.AV9SDT_ProductService = new SdtSDT_ProductService(context) ;
         this.AV19Error = new SdtSDT_Error(context) ;
         SubmitImpl();
         aP1_SDT_ProductService=this.AV9SDT_ProductService;
         aP2_Error=this.AV19Error;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( ! new prc_isauthenticated(context).executeUdp( ) )
         {
            AV19Error.gxTpr_Status = context.GetMessage( "Error", "");
            AV19Error.gxTpr_Message = context.GetMessage( "Not Authenticated", "");
         }
         else
         {
            /* Using cursor P008Q2 */
            pr_default.execute(0, new Object[] {AV8ProductServiceId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A11OrganisationId = P008Q2_A11OrganisationId[0];
               A29LocationId = P008Q2_A29LocationId[0];
               A58ProductServiceId = P008Q2_A58ProductServiceId[0];
               AV12BC_Trn_ProductService.Load(A58ProductServiceId, A29LocationId, A11OrganisationId);
               AV9SDT_ProductService.FromJSonString(AV12BC_Trn_ProductService.ToJSonString(true, true), null);
               /* Using cursor P008Q3 */
               pr_default.execute(1, new Object[] {AV8ProductServiceId, A29LocationId, A11OrganisationId});
               while ( (pr_default.getStatus(1) != 101) )
               {
                  A58ProductServiceId = P008Q3_A58ProductServiceId[0];
                  A339CallToActionId = P008Q3_A339CallToActionId[0];
                  A368CallToActionName = P008Q3_A368CallToActionName[0];
                  A342CallToActionPhone = P008Q3_A342CallToActionPhone[0];
                  A341CallToActionEmail = P008Q3_A341CallToActionEmail[0];
                  A340CallToActionType = P008Q3_A340CallToActionType[0];
                  A367CallToActionUrl = P008Q3_A367CallToActionUrl[0];
                  AV15BC_Trn_CallToAction.Load(A339CallToActionId);
                  AV13SDT_CallToActionItem = new SdtSDT_CallToAction_SDT_CallToActionItem(context);
                  AV13SDT_CallToActionItem.gxTpr_Calltoactionid = A339CallToActionId;
                  AV13SDT_CallToActionItem.gxTpr_Calltoactionname = A368CallToActionName;
                  AV13SDT_CallToActionItem.gxTpr_Calltoactionphone = A342CallToActionPhone;
                  AV13SDT_CallToActionItem.gxTpr_Calltoactionemail = A341CallToActionEmail;
                  AV13SDT_CallToActionItem.gxTpr_Calltoactiontype = A340CallToActionType;
                  AV13SDT_CallToActionItem.gxTpr_Calltoactionurl = A367CallToActionUrl;
                  AV9SDT_ProductService.gxTpr_Calltoactions.Add(AV13SDT_CallToActionItem, 0);
                  pr_default.readNext(1);
               }
               pr_default.close(1);
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
         AV9SDT_ProductService = new SdtSDT_ProductService(context);
         AV19Error = new SdtSDT_Error(context);
         P008Q2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P008Q2_A29LocationId = new Guid[] {Guid.Empty} ;
         P008Q2_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         A11OrganisationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A58ProductServiceId = Guid.Empty;
         AV12BC_Trn_ProductService = new SdtTrn_ProductService(context);
         P008Q3_A29LocationId = new Guid[] {Guid.Empty} ;
         P008Q3_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P008Q3_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         P008Q3_A339CallToActionId = new Guid[] {Guid.Empty} ;
         P008Q3_A368CallToActionName = new string[] {""} ;
         P008Q3_A342CallToActionPhone = new string[] {""} ;
         P008Q3_A341CallToActionEmail = new string[] {""} ;
         P008Q3_A340CallToActionType = new string[] {""} ;
         P008Q3_A367CallToActionUrl = new string[] {""} ;
         A339CallToActionId = Guid.Empty;
         A368CallToActionName = "";
         A342CallToActionPhone = "";
         A341CallToActionEmail = "";
         A340CallToActionType = "";
         A367CallToActionUrl = "";
         AV15BC_Trn_CallToAction = new SdtTrn_CallToAction(context);
         AV13SDT_CallToActionItem = new SdtSDT_CallToAction_SDT_CallToActionItem(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aprc_productserviceapi__default(),
            new Object[][] {
                new Object[] {
               P008Q2_A11OrganisationId, P008Q2_A29LocationId, P008Q2_A58ProductServiceId
               }
               , new Object[] {
               P008Q3_A29LocationId, P008Q3_A11OrganisationId, P008Q3_A58ProductServiceId, P008Q3_A339CallToActionId, P008Q3_A368CallToActionName, P008Q3_A342CallToActionPhone, P008Q3_A341CallToActionEmail, P008Q3_A340CallToActionType, P008Q3_A367CallToActionUrl
               }
            }
         );
         /* GeneXus formulas. */
      }

      private string A342CallToActionPhone ;
      private string A368CallToActionName ;
      private string A341CallToActionEmail ;
      private string A340CallToActionType ;
      private string A367CallToActionUrl ;
      private Guid AV8ProductServiceId ;
      private Guid A11OrganisationId ;
      private Guid A29LocationId ;
      private Guid A58ProductServiceId ;
      private Guid A339CallToActionId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDT_ProductService AV9SDT_ProductService ;
      private SdtSDT_Error AV19Error ;
      private IDataStoreProvider pr_default ;
      private Guid[] P008Q2_A11OrganisationId ;
      private Guid[] P008Q2_A29LocationId ;
      private Guid[] P008Q2_A58ProductServiceId ;
      private SdtTrn_ProductService AV12BC_Trn_ProductService ;
      private Guid[] P008Q3_A29LocationId ;
      private Guid[] P008Q3_A11OrganisationId ;
      private Guid[] P008Q3_A58ProductServiceId ;
      private Guid[] P008Q3_A339CallToActionId ;
      private string[] P008Q3_A368CallToActionName ;
      private string[] P008Q3_A342CallToActionPhone ;
      private string[] P008Q3_A341CallToActionEmail ;
      private string[] P008Q3_A340CallToActionType ;
      private string[] P008Q3_A367CallToActionUrl ;
      private SdtTrn_CallToAction AV15BC_Trn_CallToAction ;
      private SdtSDT_CallToAction_SDT_CallToActionItem AV13SDT_CallToActionItem ;
      private SdtSDT_ProductService aP1_SDT_ProductService ;
      private SdtSDT_Error aP2_Error ;
   }

   public class aprc_productserviceapi__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP008Q2;
          prmP008Q2 = new Object[] {
          new ParDef("AV8ProductServiceId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP008Q3;
          prmP008Q3 = new Object[] {
          new ParDef("AV8ProductServiceId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P008Q2", "SELECT OrganisationId, LocationId, ProductServiceId FROM Trn_ProductService WHERE ProductServiceId = :AV8ProductServiceId ORDER BY ProductServiceId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008Q2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P008Q3", "SELECT LocationId, OrganisationId, ProductServiceId, CallToActionId, CallToActionName, CallToActionPhone, CallToActionEmail, CallToActionType, CallToActionUrl FROM Trn_CallToAction WHERE ProductServiceId = :AV8ProductServiceId and LocationId = :LocationId and OrganisationId = :OrganisationId ORDER BY ProductServiceId, LocationId, OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008Q3,100, GxCacheFrequency.OFF ,true,false )
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
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((Guid[]) buf[3])[0] = rslt.getGuid(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                return;
       }
    }

 }

}
