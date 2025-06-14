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
   public class prc_defaultresidetpackage : GXProcedure
   {
      public prc_defaultresidetpackage( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_defaultresidetpackage( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_ResidentPackageId ,
                           ref Guid aP1_LocationId )
      {
         this.AV8ResidentPackageId = aP0_ResidentPackageId;
         this.AV9LocationId = aP1_LocationId;
         initialize();
         ExecuteImpl();
         aP1_LocationId=this.AV9LocationId;
      }

      public Guid executeUdp( Guid aP0_ResidentPackageId )
      {
         execute(aP0_ResidentPackageId, ref aP1_LocationId);
         return AV9LocationId ;
      }

      public void executeSubmit( Guid aP0_ResidentPackageId ,
                                 ref Guid aP1_LocationId )
      {
         this.AV8ResidentPackageId = aP0_ResidentPackageId;
         this.AV9LocationId = aP1_LocationId;
         SubmitImpl();
         aP1_LocationId=this.AV9LocationId;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Optimized UPDATE. */
         /* Using cursor P00B42 */
         pr_default.execute(0, new Object[] {AV9LocationId, AV8ResidentPackageId});
         pr_default.close(0);
         pr_default.SmartCacheProvider.SetUpdated("Trn_ResidentPackage");
         /* End optimized UPDATE. */
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("prc_defaultresidetpackage",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_defaultresidetpackage__default(),
            new Object[][] {
                new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private Guid AV8ResidentPackageId ;
      private Guid AV9LocationId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private Guid aP1_LocationId ;
      private IDataStoreProvider pr_default ;
   }

   public class prc_defaultresidetpackage__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00B42;
          prmP00B42 = new Object[] {
          new ParDef("AV9LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV8ResidentPackageId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00B42", "UPDATE Trn_ResidentPackage SET ResidentPackageDefault=FALSE  WHERE (SG_LocationId = :AV9LocationId) AND (Not ResidentPackageId = :AV8ResidentPackageId)", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00B42)
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
