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
   public class prc_addappversionpagesattributestosdt2 : GXProcedure
   {
      public prc_addappversionpagesattributestosdt2( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_addappversionpagesattributestosdt2( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_AppVersionId ,
                           GxSimpleCollection<Guid> aP1_PageIdCollection ,
                           out GXBaseCollection<SdtSDT_InfoPageTranslation> aP2_SDT_InfoPageTranslationCollection )
      {
         this.AV11AppVersionId = aP0_AppVersionId;
         this.AV14PageIdCollection = aP1_PageIdCollection;
         this.AV16SDT_InfoPageTranslationCollection = new GXBaseCollection<SdtSDT_InfoPageTranslation>( context, "SDT_InfoPageTranslation", "Comforta_version21") ;
         initialize();
         ExecuteImpl();
         aP2_SDT_InfoPageTranslationCollection=this.AV16SDT_InfoPageTranslationCollection;
      }

      public GXBaseCollection<SdtSDT_InfoPageTranslation> executeUdp( Guid aP0_AppVersionId ,
                                                                      GxSimpleCollection<Guid> aP1_PageIdCollection )
      {
         execute(aP0_AppVersionId, aP1_PageIdCollection, out aP2_SDT_InfoPageTranslationCollection);
         return AV16SDT_InfoPageTranslationCollection ;
      }

      public void executeSubmit( Guid aP0_AppVersionId ,
                                 GxSimpleCollection<Guid> aP1_PageIdCollection ,
                                 out GXBaseCollection<SdtSDT_InfoPageTranslation> aP2_SDT_InfoPageTranslationCollection )
      {
         this.AV11AppVersionId = aP0_AppVersionId;
         this.AV14PageIdCollection = aP1_PageIdCollection;
         this.AV16SDT_InfoPageTranslationCollection = new GXBaseCollection<SdtSDT_InfoPageTranslation>( context, "SDT_InfoPageTranslation", "Comforta_version21") ;
         SubmitImpl();
         aP2_SDT_InfoPageTranslationCollection=this.AV16SDT_InfoPageTranslationCollection;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A516PageId ,
                                              AV14PageIdCollection ,
                                              A525PageType ,
                                              AV11AppVersionId ,
                                              A523AppVersionId } ,
                                              new int[]{
                                              }
         });
         /* Using cursor P00GG2 */
         pr_default.execute(0, new Object[] {AV11AppVersionId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A516PageId = P00GG2_A516PageId[0];
            A525PageType = P00GG2_A525PageType[0];
            A523AppVersionId = P00GG2_A523AppVersionId[0];
            A536PagePublishedStructure = P00GG2_A536PagePublishedStructure[0];
            AV15SDT_InfoPageTranslation = new SdtSDT_InfoPageTranslation(context);
            AV15SDT_InfoPageTranslation.gxTpr_Pagetype = A525PageType;
            AV15SDT_InfoPageTranslation.gxTpr_Pageid = A516PageId;
            AV15SDT_InfoPageTranslation.gxTpr_Pagepublishedstructure = A536PagePublishedStructure;
            AV16SDT_InfoPageTranslationCollection.Add(AV15SDT_InfoPageTranslation, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
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
         AV16SDT_InfoPageTranslationCollection = new GXBaseCollection<SdtSDT_InfoPageTranslation>( context, "SDT_InfoPageTranslation", "Comforta_version21");
         A516PageId = Guid.Empty;
         A525PageType = "";
         A523AppVersionId = Guid.Empty;
         P00GG2_A516PageId = new Guid[] {Guid.Empty} ;
         P00GG2_A525PageType = new string[] {""} ;
         P00GG2_A523AppVersionId = new Guid[] {Guid.Empty} ;
         P00GG2_A536PagePublishedStructure = new string[] {""} ;
         A536PagePublishedStructure = "";
         AV15SDT_InfoPageTranslation = new SdtSDT_InfoPageTranslation(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_addappversionpagesattributestosdt2__default(),
            new Object[][] {
                new Object[] {
               P00GG2_A516PageId, P00GG2_A525PageType, P00GG2_A523AppVersionId, P00GG2_A536PagePublishedStructure
               }
            }
         );
         /* GeneXus formulas. */
      }

      private string A536PagePublishedStructure ;
      private string A525PageType ;
      private Guid AV11AppVersionId ;
      private Guid A516PageId ;
      private Guid A523AppVersionId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<Guid> AV14PageIdCollection ;
      private GXBaseCollection<SdtSDT_InfoPageTranslation> AV16SDT_InfoPageTranslationCollection ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00GG2_A516PageId ;
      private string[] P00GG2_A525PageType ;
      private Guid[] P00GG2_A523AppVersionId ;
      private string[] P00GG2_A536PagePublishedStructure ;
      private SdtSDT_InfoPageTranslation AV15SDT_InfoPageTranslation ;
      private GXBaseCollection<SdtSDT_InfoPageTranslation> aP2_SDT_InfoPageTranslationCollection ;
   }

   public class prc_addappversionpagesattributestosdt2__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00GG2( IGxContext context ,
                                             Guid A516PageId ,
                                             GxSimpleCollection<Guid> AV14PageIdCollection ,
                                             string A525PageType ,
                                             Guid AV11AppVersionId ,
                                             Guid A523AppVersionId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[1];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT PageId, PageType, AppVersionId, PagePublishedStructure FROM Trn_AppVersionPage";
         AddWhere(sWhereString, "(AppVersionId = :AV11AppVersionId)");
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV14PageIdCollection, "PageId IN (", ")")+")");
         AddWhere(sWhereString, "(PageType = ( 'Information'))");
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY AppVersionId";
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
                     return conditional_P00GG2(context, (Guid)dynConstraints[0] , (GxSimpleCollection<Guid>)dynConstraints[1] , (string)dynConstraints[2] , (Guid)dynConstraints[3] , (Guid)dynConstraints[4] );
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
          Object[] prmP00GG2;
          prmP00GG2 = new Object[] {
          new ParDef("AV11AppVersionId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00GG2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GG2,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
                return;
       }
    }

 }

}
