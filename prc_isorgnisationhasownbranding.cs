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
   public class prc_isorgnisationhasownbranding : GXProcedure
   {
      public prc_isorgnisationhasownbranding( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_isorgnisationhasownbranding( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_OrganisationId ,
                           out bool aP1_OrganisationHasOwnBrand )
      {
         this.AV8OrganisationId = aP0_OrganisationId;
         this.AV9OrganisationHasOwnBrand = false ;
         initialize();
         ExecuteImpl();
         aP1_OrganisationHasOwnBrand=this.AV9OrganisationHasOwnBrand;
      }

      public bool executeUdp( Guid aP0_OrganisationId )
      {
         execute(aP0_OrganisationId, out aP1_OrganisationHasOwnBrand);
         return AV9OrganisationHasOwnBrand ;
      }

      public void executeSubmit( Guid aP0_OrganisationId ,
                                 out bool aP1_OrganisationHasOwnBrand )
      {
         this.AV8OrganisationId = aP0_OrganisationId;
         this.AV9OrganisationHasOwnBrand = false ;
         SubmitImpl();
         aP1_OrganisationHasOwnBrand=this.AV9OrganisationHasOwnBrand;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV10GXLvl1 = 0;
         /* Using cursor P00GS2 */
         pr_default.execute(0, new Object[] {AV8OrganisationId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A11OrganisationId = P00GS2_A11OrganisationId[0];
            A537OrganisationHasOwnBrand = P00GS2_A537OrganisationHasOwnBrand[0];
            A100OrganisationSettingid = P00GS2_A100OrganisationSettingid[0];
            AV10GXLvl1 = 1;
            AV9OrganisationHasOwnBrand = A537OrganisationHasOwnBrand;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV10GXLvl1 == 0 )
         {
            AV9OrganisationHasOwnBrand = false;
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
         P00GS2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00GS2_A537OrganisationHasOwnBrand = new bool[] {false} ;
         P00GS2_A100OrganisationSettingid = new Guid[] {Guid.Empty} ;
         A11OrganisationId = Guid.Empty;
         A100OrganisationSettingid = Guid.Empty;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_isorgnisationhasownbranding__default(),
            new Object[][] {
                new Object[] {
               P00GS2_A11OrganisationId, P00GS2_A537OrganisationHasOwnBrand, P00GS2_A100OrganisationSettingid
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV10GXLvl1 ;
      private bool AV9OrganisationHasOwnBrand ;
      private bool A537OrganisationHasOwnBrand ;
      private Guid AV8OrganisationId ;
      private Guid A11OrganisationId ;
      private Guid A100OrganisationSettingid ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00GS2_A11OrganisationId ;
      private bool[] P00GS2_A537OrganisationHasOwnBrand ;
      private Guid[] P00GS2_A100OrganisationSettingid ;
      private bool aP1_OrganisationHasOwnBrand ;
   }

   public class prc_isorgnisationhasownbranding__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00GS2;
          prmP00GS2 = new Object[] {
          new ParDef("AV8OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00GS2", "SELECT OrganisationId, OrganisationHasOwnBrand, OrganisationSettingid FROM Trn_OrganisationSetting WHERE OrganisationId = :AV8OrganisationId ORDER BY OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GS2,100, GxCacheFrequency.OFF ,false,false )
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
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                return;
       }
    }

 }

}
