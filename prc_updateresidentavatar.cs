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
   public class prc_updateresidentavatar : GXProcedure
   {
      public prc_updateresidentavatar( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_updateresidentavatar( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_base64Image ,
                           string aP1_ResidentGUID ,
                           out string aP2_response )
      {
         this.AV8base64Image = aP0_base64Image;
         this.AV11ResidentGUID = aP1_ResidentGUID;
         this.AV14response = "" ;
         initialize();
         ExecuteImpl();
         aP2_response=this.AV14response;
      }

      public string executeUdp( string aP0_base64Image ,
                                string aP1_ResidentGUID )
      {
         execute(aP0_base64Image, aP1_ResidentGUID, out aP2_response);
         return AV14response ;
      }

      public void executeSubmit( string aP0_base64Image ,
                                 string aP1_ResidentGUID ,
                                 out string aP2_response )
      {
         this.AV8base64Image = aP0_base64Image;
         this.AV11ResidentGUID = aP1_ResidentGUID;
         this.AV14response = "" ;
         SubmitImpl();
         aP2_response=this.AV14response;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8base64Image)) )
         {
            if ( StringUtil.Contains( AV8base64Image, ",") )
            {
               AV12base64String = GxRegex.Split(AV8base64Image,",").GetString(2);
            }
            else
            {
               AV12base64String = AV8base64Image;
            }
         }
         AV10Blob=context.FileFromBase64( AV12base64String) ;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10Blob)) )
         {
            AV17GXLvl13 = 0;
            /* Using cursor P009Q2 */
            pr_default.execute(0, new Object[] {AV11ResidentGUID});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A71ResidentGUID = P009Q2_A71ResidentGUID[0];
               A40000ResidentImage_GXI = P009Q2_A40000ResidentImage_GXI[0];
               n40000ResidentImage_GXI = P009Q2_n40000ResidentImage_GXI[0];
               A62ResidentId = P009Q2_A62ResidentId[0];
               A29LocationId = P009Q2_A29LocationId[0];
               A11OrganisationId = P009Q2_A11OrganisationId[0];
               A445ResidentImage = P009Q2_A445ResidentImage[0];
               n445ResidentImage = P009Q2_n445ResidentImage[0];
               AV17GXLvl13 = 1;
               A445ResidentImage = AV10Blob;
               n445ResidentImage = false;
               A40000ResidentImage_GXI = GXDbFile.GetUriFromFile( "", "", AV10Blob);
               n40000ResidentImage_GXI = false;
               AV16isSuccessful = true;
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               /* Using cursor P009Q3 */
               pr_default.execute(1, new Object[] {n445ResidentImage, A445ResidentImage, n40000ResidentImage_GXI, A40000ResidentImage_GXI, A62ResidentId, A29LocationId, A11OrganisationId});
               pr_default.close(1);
               pr_default.SmartCacheProvider.SetUpdated("Trn_Resident");
               if (true) break;
               /* Using cursor P009Q4 */
               pr_default.execute(2, new Object[] {n445ResidentImage, A445ResidentImage, n40000ResidentImage_GXI, A40000ResidentImage_GXI, A62ResidentId, A29LocationId, A11OrganisationId});
               pr_default.close(2);
               pr_default.SmartCacheProvider.SetUpdated("Trn_Resident");
               pr_default.readNext(0);
            }
            pr_default.close(0);
            if ( AV17GXLvl13 == 0 )
            {
               AV16isSuccessful = false;
            }
            if ( AV16isSuccessful )
            {
               context.CommitDataStores("prc_updateresidentavatar",pr_default);
               AV15WWP_UserExtended.Load(AV11ResidentGUID);
               AV15WWP_UserExtended.gxTpr_Wwpuserextendedphoto = AV10Blob;
               AV15WWP_UserExtended.gxTpr_Wwpuserextendedphoto_gxi = GXDbFile.GetUriFromFile( "", "", AV10Blob);
               AV15WWP_UserExtended.Save();
               if ( AV15WWP_UserExtended.Success() )
               {
                  context.CommitDataStores("prc_updateresidentavatar",pr_default);
                  AV14response = context.GetMessage( "Profile updated sucessfully", "");
               }
            }
            else
            {
               context.RollbackDataStores("prc_updateresidentavatar",pr_default);
               AV14response = context.GetMessage( "User profile could not be updated. Try again ", "");
            }
         }
         else
         {
            AV14response = context.GetMessage( "Uploaded image could not be processed, try another", "");
         }
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("prc_updateresidentavatar",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV14response = "";
         AV12base64String = "";
         AV10Blob = "";
         P009Q2_A71ResidentGUID = new string[] {""} ;
         P009Q2_A40000ResidentImage_GXI = new string[] {""} ;
         P009Q2_n40000ResidentImage_GXI = new bool[] {false} ;
         P009Q2_A62ResidentId = new Guid[] {Guid.Empty} ;
         P009Q2_A29LocationId = new Guid[] {Guid.Empty} ;
         P009Q2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P009Q2_A445ResidentImage = new string[] {""} ;
         P009Q2_n445ResidentImage = new bool[] {false} ;
         A71ResidentGUID = "";
         A40000ResidentImage_GXI = "";
         A62ResidentId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         A445ResidentImage = "";
         AV15WWP_UserExtended = new GeneXus.Programs.wwpbaseobjects.SdtWWP_UserExtended(context);
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.prc_updateresidentavatar__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.prc_updateresidentavatar__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_updateresidentavatar__default(),
            new Object[][] {
                new Object[] {
               P009Q2_A71ResidentGUID, P009Q2_A40000ResidentImage_GXI, P009Q2_n40000ResidentImage_GXI, P009Q2_A62ResidentId, P009Q2_A29LocationId, P009Q2_A11OrganisationId, P009Q2_A445ResidentImage, P009Q2_n445ResidentImage
               }
               , new Object[] {
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV17GXLvl13 ;
      private bool n40000ResidentImage_GXI ;
      private bool n445ResidentImage ;
      private bool AV16isSuccessful ;
      private string AV8base64Image ;
      private string AV12base64String ;
      private string AV11ResidentGUID ;
      private string AV14response ;
      private string A71ResidentGUID ;
      private string A40000ResidentImage_GXI ;
      private string A445ResidentImage ;
      private Guid A62ResidentId ;
      private Guid A29LocationId ;
      private Guid A11OrganisationId ;
      private string AV10Blob ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P009Q2_A71ResidentGUID ;
      private string[] P009Q2_A40000ResidentImage_GXI ;
      private bool[] P009Q2_n40000ResidentImage_GXI ;
      private Guid[] P009Q2_A62ResidentId ;
      private Guid[] P009Q2_A29LocationId ;
      private Guid[] P009Q2_A11OrganisationId ;
      private string[] P009Q2_A445ResidentImage ;
      private bool[] P009Q2_n445ResidentImage ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWP_UserExtended AV15WWP_UserExtended ;
      private string aP2_response ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class prc_updateresidentavatar__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class prc_updateresidentavatar__gam : DataStoreHelperBase, IDataStoreHelper
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

public class prc_updateresidentavatar__default : DataStoreHelperBase, IDataStoreHelper
{
   public ICursor[] getCursors( )
   {
      cursorDefinitions();
      return new Cursor[] {
       new ForEachCursor(def[0])
      ,new UpdateCursor(def[1])
      ,new UpdateCursor(def[2])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmP009Q2;
       prmP009Q2 = new Object[] {
       new ParDef("AV11ResidentGUID",GXType.VarChar,100,60)
       };
       Object[] prmP009Q3;
       prmP009Q3 = new Object[] {
       new ParDef("ResidentImage",GXType.Byte,1024,0){Nullable=true,InDB=false} ,
       new ParDef("ResidentImage_GXI",GXType.VarChar,2048,0){Nullable=true,AddAtt=true, ImgIdx=0, Tbl="Trn_Resident", Fld="ResidentImage"} ,
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmP009Q4;
       prmP009Q4 = new Object[] {
       new ParDef("ResidentImage",GXType.Byte,1024,0){Nullable=true,InDB=false} ,
       new ParDef("ResidentImage_GXI",GXType.VarChar,2048,0){Nullable=true,AddAtt=true, ImgIdx=0, Tbl="Trn_Resident", Fld="ResidentImage"} ,
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("P009Q2", "SELECT ResidentGUID, ResidentImage_GXI, ResidentId, LocationId, OrganisationId, ResidentImage FROM Trn_Resident WHERE ResidentGUID = ( :AV11ResidentGUID) ORDER BY ResidentId, LocationId, OrganisationId  FOR UPDATE OF Trn_Resident",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009Q2,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("P009Q3", "SAVEPOINT gxupdate;UPDATE Trn_Resident SET ResidentImage=:ResidentImage, ResidentImage_GXI=:ResidentImage_GXI  WHERE ResidentId = :ResidentId AND LocationId = :LocationId AND OrganisationId = :OrganisationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP009Q3)
          ,new CursorDef("P009Q4", "SAVEPOINT gxupdate;UPDATE Trn_Resident SET ResidentImage=:ResidentImage, ResidentImage_GXI=:ResidentImage_GXI  WHERE ResidentId = :ResidentId AND LocationId = :LocationId AND OrganisationId = :OrganisationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP009Q4)
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
             ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
             ((bool[]) buf[2])[0] = rslt.wasNull(2);
             ((Guid[]) buf[3])[0] = rslt.getGuid(3);
             ((Guid[]) buf[4])[0] = rslt.getGuid(4);
             ((Guid[]) buf[5])[0] = rslt.getGuid(5);
             ((string[]) buf[6])[0] = rslt.getMultimediaFile(6, rslt.getVarchar(2));
             ((bool[]) buf[7])[0] = rslt.wasNull(6);
             return;
    }
 }

}

}
