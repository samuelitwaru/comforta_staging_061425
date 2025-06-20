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
   public class aprc_listpages : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new aprc_listpages().MainImpl(args); ;
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
            return GAMSecurityLevel.SecurityLow ;
         }

      }

      public aprc_listpages( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aprc_listpages( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out GXBaseCollection<SdtSDT_PageStructure> aP0_SDT_PageStructureCollection ,
                           out SdtSDT_Error aP1_Error )
      {
         this.AV28SDT_PageStructureCollection = new GXBaseCollection<SdtSDT_PageStructure>( context, "SDT_PageStructure", "Comforta_version2") ;
         this.AV30Error = new SdtSDT_Error(context) ;
         initialize();
         ExecuteImpl();
         aP0_SDT_PageStructureCollection=this.AV28SDT_PageStructureCollection;
         aP1_Error=this.AV30Error;
      }

      public SdtSDT_Error executeUdp( out GXBaseCollection<SdtSDT_PageStructure> aP0_SDT_PageStructureCollection )
      {
         execute(out aP0_SDT_PageStructureCollection, out aP1_Error);
         return AV30Error ;
      }

      public void executeSubmit( out GXBaseCollection<SdtSDT_PageStructure> aP0_SDT_PageStructureCollection ,
                                 out SdtSDT_Error aP1_Error )
      {
         this.AV28SDT_PageStructureCollection = new GXBaseCollection<SdtSDT_PageStructure>( context, "SDT_PageStructure", "Comforta_version2") ;
         this.AV30Error = new SdtSDT_Error(context) ;
         SubmitImpl();
         aP0_SDT_PageStructureCollection=this.AV28SDT_PageStructureCollection;
         aP1_Error=this.AV30Error;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( ! new prc_isauthenticated(context).executeUdp( ) )
         {
            AV30Error.gxTpr_Status = context.GetMessage( "Error", "");
            AV30Error.gxTpr_Message = context.GetMessage( "Not Authenticated", "");
         }
         else
         {
            AV32Udparg1 = new prc_getuserlocationid(context).executeUdp( );
            AV33Udparg2 = new prc_getuserorganisationid(context).executeUdp( );
            /* Using cursor P008K2 */
            pr_default.execute(0, new Object[] {AV32Udparg1, AV33Udparg2});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A397Trn_PageName = P008K2_A397Trn_PageName[0];
               A11OrganisationId = P008K2_A11OrganisationId[0];
               A29LocationId = P008K2_A29LocationId[0];
               A420PageJsonContent = P008K2_A420PageJsonContent[0];
               n420PageJsonContent = P008K2_n420PageJsonContent[0];
               A392Trn_PageId = P008K2_A392Trn_PageId[0];
               if ( StringUtil.StrCmp(A397Trn_PageName, context.GetMessage( "Home", "")) == 0 )
               {
                  AV8SDT_Page = new SdtSDT_Page(context);
                  AV8SDT_Page.FromJSonString(A420PageJsonContent, null);
                  AV34GXV1 = 1;
                  while ( AV34GXV1 <= AV8SDT_Page.gxTpr_Row.Count )
                  {
                     AV10SDT_Row = ((SdtSDT_Row)AV8SDT_Page.gxTpr_Row.Item(AV34GXV1));
                     AV35GXV2 = 1;
                     while ( AV35GXV2 <= AV10SDT_Row.gxTpr_Col.Count )
                     {
                        AV11SDT_Col = ((SdtSDT_Col)AV10SDT_Row.gxTpr_Col.Item(AV35GXV2));
                        if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV11SDT_Col.gxTpr_Tile.gxTpr_Tileaction.gxTpr_Objecttype))) )
                        {
                           AV25BC_Trn_Page = new SdtTrn_Page(context);
                           AV25BC_Trn_Page.Load(StringUtil.StrToGuid( AV11SDT_Col.gxTpr_Tile.gxTpr_Tileaction.gxTpr_Objectid), new prc_getuserlocationid(context).executeUdp( ));
                           if ( ! (Guid.Empty==AV25BC_Trn_Page.gxTpr_Trn_pageid) )
                           {
                              AV15SDT_PageStructure = new SdtSDT_PageStructure(context);
                              AV15SDT_PageStructure.gxTpr_Id = AV25BC_Trn_Page.gxTpr_Trn_pageid;
                              AV15SDT_PageStructure.gxTpr_Name = AV25BC_Trn_Page.gxTpr_Trn_pagename;
                              if ( ! AV25BC_Trn_Page.gxTpr_Pageiscontentpage )
                              {
                                 AV8SDT_Page = new SdtSDT_Page(context);
                                 AV8SDT_Page.FromJSonString(AV25BC_Trn_Page.gxTpr_Pagejsoncontent, null);
                                 AV36GXV3 = 1;
                                 while ( AV36GXV3 <= AV8SDT_Page.gxTpr_Row.Count )
                                 {
                                    AV10SDT_Row = ((SdtSDT_Row)AV8SDT_Page.gxTpr_Row.Item(AV36GXV3));
                                    AV37GXV4 = 1;
                                    while ( AV37GXV4 <= AV10SDT_Row.gxTpr_Col.Count )
                                    {
                                       AV11SDT_Col = ((SdtSDT_Col)AV10SDT_Row.gxTpr_Col.Item(AV37GXV4));
                                       if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV11SDT_Col.gxTpr_Tile.gxTpr_Tileaction.gxTpr_Objecttype))) )
                                       {
                                          AV25BC_Trn_Page = new SdtTrn_Page(context);
                                          AV25BC_Trn_Page.Load(StringUtil.StrToGuid( AV11SDT_Col.gxTpr_Tile.gxTpr_Tileaction.gxTpr_Objectid), new prc_getuserlocationid(context).executeUdp( ));
                                          if ( ! (Guid.Empty==AV25BC_Trn_Page.gxTpr_Trn_pageid) )
                                          {
                                             AV19SDT_PageChild = new SdtSDT_PageStructure_ChildrenItem(context);
                                             AV19SDT_PageChild.gxTpr_Id = AV25BC_Trn_Page.gxTpr_Trn_pageid;
                                             AV19SDT_PageChild.gxTpr_Name = AV25BC_Trn_Page.gxTpr_Trn_pagename;
                                             AV15SDT_PageStructure.gxTpr_Children.Add(AV19SDT_PageChild, 0);
                                          }
                                       }
                                       AV37GXV4 = (int)(AV37GXV4+1);
                                    }
                                    AV36GXV3 = (int)(AV36GXV3+1);
                                 }
                              }
                              AV28SDT_PageStructureCollection.Add(AV15SDT_PageStructure, 0);
                           }
                        }
                        AV35GXV2 = (int)(AV35GXV2+1);
                     }
                     AV34GXV1 = (int)(AV34GXV1+1);
                  }
               }
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
         AV28SDT_PageStructureCollection = new GXBaseCollection<SdtSDT_PageStructure>( context, "SDT_PageStructure", "Comforta_version2");
         AV30Error = new SdtSDT_Error(context);
         AV32Udparg1 = Guid.Empty;
         AV33Udparg2 = Guid.Empty;
         P008K2_A397Trn_PageName = new string[] {""} ;
         P008K2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P008K2_A29LocationId = new Guid[] {Guid.Empty} ;
         P008K2_A420PageJsonContent = new string[] {""} ;
         P008K2_n420PageJsonContent = new bool[] {false} ;
         P008K2_A392Trn_PageId = new Guid[] {Guid.Empty} ;
         A397Trn_PageName = "";
         A11OrganisationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A420PageJsonContent = "";
         A392Trn_PageId = Guid.Empty;
         AV8SDT_Page = new SdtSDT_Page(context);
         AV10SDT_Row = new SdtSDT_Row(context);
         AV11SDT_Col = new SdtSDT_Col(context);
         AV25BC_Trn_Page = new SdtTrn_Page(context);
         AV15SDT_PageStructure = new SdtSDT_PageStructure(context);
         AV19SDT_PageChild = new SdtSDT_PageStructure_ChildrenItem(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aprc_listpages__default(),
            new Object[][] {
                new Object[] {
               P008K2_A397Trn_PageName, P008K2_A11OrganisationId, P008K2_A29LocationId, P008K2_A420PageJsonContent, P008K2_n420PageJsonContent, P008K2_A392Trn_PageId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int AV34GXV1 ;
      private int AV35GXV2 ;
      private int AV36GXV3 ;
      private int AV37GXV4 ;
      private bool n420PageJsonContent ;
      private string A420PageJsonContent ;
      private string A397Trn_PageName ;
      private Guid AV32Udparg1 ;
      private Guid AV33Udparg2 ;
      private Guid A11OrganisationId ;
      private Guid A29LocationId ;
      private Guid A392Trn_PageId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtSDT_PageStructure> AV28SDT_PageStructureCollection ;
      private SdtSDT_Error AV30Error ;
      private IDataStoreProvider pr_default ;
      private string[] P008K2_A397Trn_PageName ;
      private Guid[] P008K2_A11OrganisationId ;
      private Guid[] P008K2_A29LocationId ;
      private string[] P008K2_A420PageJsonContent ;
      private bool[] P008K2_n420PageJsonContent ;
      private Guid[] P008K2_A392Trn_PageId ;
      private SdtSDT_Page AV8SDT_Page ;
      private SdtSDT_Row AV10SDT_Row ;
      private SdtSDT_Col AV11SDT_Col ;
      private SdtTrn_Page AV25BC_Trn_Page ;
      private SdtSDT_PageStructure AV15SDT_PageStructure ;
      private SdtSDT_PageStructure_ChildrenItem AV19SDT_PageChild ;
      private GXBaseCollection<SdtSDT_PageStructure> aP0_SDT_PageStructureCollection ;
      private SdtSDT_Error aP1_Error ;
   }

   public class aprc_listpages__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP008K2;
          prmP008K2 = new Object[] {
          new ParDef("AV32Udparg1",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV33Udparg2",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P008K2", "SELECT Trn_PageName, OrganisationId, LocationId, PageJsonContent, Trn_PageId FROM Trn_Page WHERE (LocationId = :AV32Udparg1) AND (OrganisationId = :AV33Udparg2) ORDER BY Trn_PageId, LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008K2,100, GxCacheFrequency.OFF ,true,false )
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
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((Guid[]) buf[5])[0] = rslt.getGuid(5);
                return;
       }
    }

 }

}
