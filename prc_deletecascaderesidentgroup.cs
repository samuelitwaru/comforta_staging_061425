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
   public class prc_deletecascaderesidentgroup : GXProcedure
   {
      public prc_deletecascaderesidentgroup( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_deletecascaderesidentgroup( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_GroupId ,
                           Guid aP1_LocationId )
      {
         this.AV13GroupId = aP0_GroupId;
         this.AV12LocationId = aP1_LocationId;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( Guid aP0_GroupId ,
                                 Guid aP1_LocationId )
      {
         this.AV13GroupId = aP0_GroupId;
         this.AV12LocationId = aP1_LocationId;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00H72 */
         pr_default.execute(0, new Object[] {AV12LocationId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A29LocationId = P00H72_A29LocationId[0];
            A670ResidentGroups = P00H72_A670ResidentGroups[0];
            n670ResidentGroups = P00H72_n670ResidentGroups[0];
            A62ResidentId = P00H72_A62ResidentId[0];
            A11OrganisationId = P00H72_A11OrganisationId[0];
            AV11ResidentPackageIdCollection = (GxSimpleCollection<Guid>)(new GxSimpleCollection<Guid>());
            if ( AV11ResidentPackageIdCollection.FromJSonString(A670ResidentGroups, null) )
            {
               AV16GXV1 = 1;
               while ( AV16GXV1 <= AV11ResidentPackageIdCollection.Count )
               {
                  AV8ResidentPackageId = ((Guid)AV11ResidentPackageIdCollection.Item(AV16GXV1));
                  if ( AV8ResidentPackageId == AV13GroupId )
                  {
                     AV14GroupIndexToDelete = (short)(AV11ResidentPackageIdCollection.IndexOf(AV8ResidentPackageId));
                  }
                  AV16GXV1 = (int)(AV16GXV1+1);
               }
               if ( AV14GroupIndexToDelete != -1 )
               {
                  AV11ResidentPackageIdCollection.RemoveItem(AV14GroupIndexToDelete);
               }
               A670ResidentGroups = AV11ResidentPackageIdCollection.ToJSonString(false);
               n670ResidentGroups = false;
            }
            /* Using cursor P00H73 */
            pr_default.execute(1, new Object[] {n670ResidentGroups, A670ResidentGroups, A62ResidentId, A29LocationId, A11OrganisationId});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("Trn_Resident");
            pr_default.readNext(0);
         }
         pr_default.close(0);
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("prc_deletecascaderesidentgroup",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         P00H72_A29LocationId = new Guid[] {Guid.Empty} ;
         P00H72_A670ResidentGroups = new string[] {""} ;
         P00H72_n670ResidentGroups = new bool[] {false} ;
         P00H72_A62ResidentId = new Guid[] {Guid.Empty} ;
         P00H72_A11OrganisationId = new Guid[] {Guid.Empty} ;
         A29LocationId = Guid.Empty;
         A670ResidentGroups = "";
         A62ResidentId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         AV11ResidentPackageIdCollection = new GxSimpleCollection<Guid>();
         AV8ResidentPackageId = Guid.Empty;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_deletecascaderesidentgroup__default(),
            new Object[][] {
                new Object[] {
               P00H72_A29LocationId, P00H72_A670ResidentGroups, P00H72_n670ResidentGroups, P00H72_A62ResidentId, P00H72_A11OrganisationId
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV14GroupIndexToDelete ;
      private int AV16GXV1 ;
      private bool n670ResidentGroups ;
      private string A670ResidentGroups ;
      private Guid AV13GroupId ;
      private Guid AV12LocationId ;
      private Guid A29LocationId ;
      private Guid A62ResidentId ;
      private Guid A11OrganisationId ;
      private Guid AV8ResidentPackageId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00H72_A29LocationId ;
      private string[] P00H72_A670ResidentGroups ;
      private bool[] P00H72_n670ResidentGroups ;
      private Guid[] P00H72_A62ResidentId ;
      private Guid[] P00H72_A11OrganisationId ;
      private GxSimpleCollection<Guid> AV11ResidentPackageIdCollection ;
   }

   public class prc_deletecascaderesidentgroup__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00H72;
          prmP00H72 = new Object[] {
          new ParDef("AV12LocationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00H73;
          prmP00H73 = new Object[] {
          new ParDef("ResidentGroups",GXType.LongVarChar,1048576,0){Nullable=true} ,
          new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00H72", "SELECT LocationId, ResidentGroups, ResidentId, OrganisationId FROM Trn_Resident WHERE LocationId = :AV12LocationId ORDER BY LocationId  FOR UPDATE OF Trn_Resident",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00H72,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00H73", "SAVEPOINT gxupdate;UPDATE Trn_Resident SET ResidentGroups=:ResidentGroups  WHERE ResidentId = :ResidentId AND LocationId = :LocationId AND OrganisationId = :OrganisationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00H73)
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
