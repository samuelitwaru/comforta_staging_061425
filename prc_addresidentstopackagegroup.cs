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
   public class prc_addresidentstopackagegroup : GXProcedure
   {
      public prc_addresidentstopackagegroup( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_addresidentstopackagegroup( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_ResidentPackageId ,
                           GxSimpleCollection<Guid> aP1_ListOfResidentIds )
      {
         this.AV8ResidentPackageId = aP0_ResidentPackageId;
         this.AV9ListOfResidentIds = aP1_ListOfResidentIds;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( Guid aP0_ResidentPackageId ,
                                 GxSimpleCollection<Guid> aP1_ListOfResidentIds )
      {
         this.AV8ResidentPackageId = aP0_ResidentPackageId;
         this.AV9ListOfResidentIds = aP1_ListOfResidentIds;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         new prc_logtofile(context ).execute(  context.GetMessage( "ResidentIds to add......", "")+AV9ListOfResidentIds.ToJSonString(false)) ;
         if ( AV9ListOfResidentIds.Count > 0 )
         {
            AV12GXV1 = 1;
            while ( AV12GXV1 <= AV9ListOfResidentIds.Count )
            {
               AV10ResidentListIdItem = ((Guid)AV9ListOfResidentIds.Item(AV12GXV1));
               /* Using cursor P00H62 */
               pr_default.execute(0, new Object[] {AV10ResidentListIdItem});
               while ( (pr_default.getStatus(0) != 101) )
               {
                  A62ResidentId = P00H62_A62ResidentId[0];
                  A670ResidentGroups = P00H62_A670ResidentGroups[0];
                  n670ResidentGroups = P00H62_n670ResidentGroups[0];
                  A29LocationId = P00H62_A29LocationId[0];
                  A11OrganisationId = P00H62_A11OrganisationId[0];
                  AV11ResidentPackageIdCollection = (GxSimpleCollection<Guid>)(new GxSimpleCollection<Guid>());
                  AV11ResidentPackageIdCollection.FromJSonString(A670ResidentGroups, null);
                  AV11ResidentPackageIdCollection.Add(AV8ResidentPackageId, 0);
                  A670ResidentGroups = AV11ResidentPackageIdCollection.ToJSonString(false);
                  n670ResidentGroups = false;
                  /* Using cursor P00H63 */
                  pr_default.execute(1, new Object[] {n670ResidentGroups, A670ResidentGroups, A62ResidentId, A29LocationId, A11OrganisationId});
                  pr_default.close(1);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_Resident");
                  pr_default.readNext(0);
               }
               pr_default.close(0);
               AV12GXV1 = (int)(AV12GXV1+1);
            }
         }
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("prc_addresidentstopackagegroup",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV10ResidentListIdItem = Guid.Empty;
         P00H62_A62ResidentId = new Guid[] {Guid.Empty} ;
         P00H62_A670ResidentGroups = new string[] {""} ;
         P00H62_n670ResidentGroups = new bool[] {false} ;
         P00H62_A29LocationId = new Guid[] {Guid.Empty} ;
         P00H62_A11OrganisationId = new Guid[] {Guid.Empty} ;
         A62ResidentId = Guid.Empty;
         A670ResidentGroups = "";
         A29LocationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         AV11ResidentPackageIdCollection = new GxSimpleCollection<Guid>();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_addresidentstopackagegroup__default(),
            new Object[][] {
                new Object[] {
               P00H62_A62ResidentId, P00H62_A670ResidentGroups, P00H62_n670ResidentGroups, P00H62_A29LocationId, P00H62_A11OrganisationId
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int AV12GXV1 ;
      private bool n670ResidentGroups ;
      private string A670ResidentGroups ;
      private Guid AV8ResidentPackageId ;
      private Guid AV10ResidentListIdItem ;
      private Guid A62ResidentId ;
      private Guid A29LocationId ;
      private Guid A11OrganisationId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<Guid> AV9ListOfResidentIds ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00H62_A62ResidentId ;
      private string[] P00H62_A670ResidentGroups ;
      private bool[] P00H62_n670ResidentGroups ;
      private Guid[] P00H62_A29LocationId ;
      private Guid[] P00H62_A11OrganisationId ;
      private GxSimpleCollection<Guid> AV11ResidentPackageIdCollection ;
   }

   public class prc_addresidentstopackagegroup__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new UpdateCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00H62;
          prmP00H62 = new Object[] {
          new ParDef("AV10ResidentListIdItem",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00H63;
          prmP00H63 = new Object[] {
          new ParDef("ResidentGroups",GXType.LongVarChar,1048576,0){Nullable=true} ,
          new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00H62", "SELECT ResidentId, ResidentGroups, LocationId, OrganisationId FROM Trn_Resident WHERE ResidentId = :AV10ResidentListIdItem ORDER BY ResidentId  FOR UPDATE OF Trn_Resident",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00H62,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00H63", "SAVEPOINT gxupdate;UPDATE Trn_Resident SET ResidentGroups=:ResidentGroups  WHERE ResidentId = :ResidentId AND LocationId = :LocationId AND OrganisationId = :OrganisationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00H63)
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
                ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((Guid[]) buf[3])[0] = rslt.getGuid(3);
                ((Guid[]) buf[4])[0] = rslt.getGuid(4);
                return;
       }
    }

 }

}
