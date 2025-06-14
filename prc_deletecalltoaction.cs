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
   public class prc_deletecalltoaction : GXProcedure
   {
      public prc_deletecalltoaction( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_deletecalltoaction( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_OrganisationId ,
                           Guid aP1_LocationId ,
                           Guid aP2_ProductServiceId ,
                           Guid aP3_CallToActionId )
      {
         this.AV10OrganisationId = aP0_OrganisationId;
         this.AV8LocationId = aP1_LocationId;
         this.AV9ProductServiceId = aP2_ProductServiceId;
         this.AV11CallToActionId = aP3_CallToActionId;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( Guid aP0_OrganisationId ,
                                 Guid aP1_LocationId ,
                                 Guid aP2_ProductServiceId ,
                                 Guid aP3_CallToActionId )
      {
         this.AV10OrganisationId = aP0_OrganisationId;
         this.AV8LocationId = aP1_LocationId;
         this.AV9ProductServiceId = aP2_ProductServiceId;
         this.AV11CallToActionId = aP3_CallToActionId;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Optimized DELETE. */
         /* Using cursor P007J2 */
         pr_default.execute(0, new Object[] {AV9ProductServiceId, AV8LocationId, AV10OrganisationId, AV11CallToActionId});
         pr_default.close(0);
         pr_default.SmartCacheProvider.SetUpdated("Trn_CallToAction");
         /* End optimized DELETE. */
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("prc_deletecalltoaction",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_deletecalltoaction__default(),
            new Object[][] {
                new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private Guid AV10OrganisationId ;
      private Guid AV8LocationId ;
      private Guid AV9ProductServiceId ;
      private Guid AV11CallToActionId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
   }

   public class prc_deletecalltoaction__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new UpdateCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP007J2;
          prmP007J2 = new Object[] {
          new ParDef("AV9ProductServiceId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV8LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV10OrganisationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV11CallToActionId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007J2", "DELETE FROM Trn_CallToAction  WHERE (ProductServiceId = :AV9ProductServiceId and LocationId = :AV8LocationId and OrganisationId = :AV10OrganisationId) AND (CallToActionId = :AV11CallToActionId)", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP007J2)
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
