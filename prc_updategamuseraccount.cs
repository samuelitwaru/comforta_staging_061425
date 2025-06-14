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
   public class prc_updategamuseraccount : GXProcedure
   {
      public prc_updategamuseraccount( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_updategamuseraccount( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_UserGAMGUID ,
                           string aP1_GivenName ,
                           string aP2_LastName ,
                           string aP3_PhoneCode ,
                           string aP4_PhoneNumber ,
                           string aP5_ProfileImage ,
                           bool aP6_IsActive ,
                           string aP7_Role ,
                           out string aP8_GAMErrorResponse )
      {
         this.AV12UserGAMGUID = aP0_UserGAMGUID;
         this.AV10GivenName = aP1_GivenName;
         this.AV11LastName = aP2_LastName;
         this.AV18PhoneCode = aP3_PhoneCode;
         this.AV20PhoneNumber = aP4_PhoneNumber;
         this.AV19ProfileImage = aP5_ProfileImage;
         this.AV14IsActive = aP6_IsActive;
         this.AV15Role = aP7_Role;
         this.AV8GAMErrorResponse = "" ;
         initialize();
         ExecuteImpl();
         aP8_GAMErrorResponse=this.AV8GAMErrorResponse;
      }

      public string executeUdp( string aP0_UserGAMGUID ,
                                string aP1_GivenName ,
                                string aP2_LastName ,
                                string aP3_PhoneCode ,
                                string aP4_PhoneNumber ,
                                string aP5_ProfileImage ,
                                bool aP6_IsActive ,
                                string aP7_Role )
      {
         execute(aP0_UserGAMGUID, aP1_GivenName, aP2_LastName, aP3_PhoneCode, aP4_PhoneNumber, aP5_ProfileImage, aP6_IsActive, aP7_Role, out aP8_GAMErrorResponse);
         return AV8GAMErrorResponse ;
      }

      public void executeSubmit( string aP0_UserGAMGUID ,
                                 string aP1_GivenName ,
                                 string aP2_LastName ,
                                 string aP3_PhoneCode ,
                                 string aP4_PhoneNumber ,
                                 string aP5_ProfileImage ,
                                 bool aP6_IsActive ,
                                 string aP7_Role ,
                                 out string aP8_GAMErrorResponse )
      {
         this.AV12UserGAMGUID = aP0_UserGAMGUID;
         this.AV10GivenName = aP1_GivenName;
         this.AV11LastName = aP2_LastName;
         this.AV18PhoneCode = aP3_PhoneCode;
         this.AV20PhoneNumber = aP4_PhoneNumber;
         this.AV19ProfileImage = aP5_ProfileImage;
         this.AV14IsActive = aP6_IsActive;
         this.AV15Role = aP7_Role;
         this.AV8GAMErrorResponse = "" ;
         SubmitImpl();
         aP8_GAMErrorResponse=this.AV8GAMErrorResponse;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9GAMUser.load( AV12UserGAMGUID);
         if ( AV9GAMUser.success() )
         {
            AV9GAMUser.gxTpr_Firstname = AV10GivenName;
            AV9GAMUser.gxTpr_Lastname = AV11LastName;
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20PhoneNumber)) )
            {
               AV9GAMUser.gxTpr_Phone = AV18PhoneCode+"~"+AV20PhoneNumber;
            }
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV19ProfileImage)) && String.IsNullOrEmpty(StringUtil.RTrim( AV22Profileimage_GXI)) ) )
            {
               AV9GAMUser.gxTpr_Urlprofile = AV22Profileimage_GXI;
            }
            if ( StringUtil.StrCmp(AV15Role, "Resident") != 0 )
            {
               if ( ( AV14IsActive ) && ( AV9GAMUser.gxTpr_Isblocked ) )
               {
                  AV9GAMUser.unblockaccess(out  AV13GAMErrorCollection);
               }
               if ( ! AV14IsActive && ! AV9GAMUser.gxTpr_Isblocked )
               {
                  AV9GAMUser.blockaccess( false,  false, out  AV13GAMErrorCollection);
               }
            }
            AV9GAMUser.save();
            if ( AV9GAMUser.success() )
            {
               context.CommitDataStores("prc_updategamuseraccount",pr_default);
            }
            else
            {
               AV13GAMErrorCollection = AV9GAMUser.geterrors();
               GXt_char1 = AV8GAMErrorResponse;
               new prc_geterrorstringfromcollection(context ).execute(  AV13GAMErrorCollection, out  GXt_char1) ;
               AV8GAMErrorResponse = GXt_char1;
            }
         }
         else
         {
            AV13GAMErrorCollection = AV9GAMUser.geterrors();
            GXt_char1 = AV8GAMErrorResponse;
            new prc_geterrorstringfromcollection(context ).execute(  AV13GAMErrorCollection, out  GXt_char1) ;
            AV8GAMErrorResponse = GXt_char1;
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
         AV8GAMErrorResponse = "";
         AV9GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV22Profileimage_GXI = "";
         AV13GAMErrorCollection = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         GXt_char1 = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.prc_updategamuseraccount__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.prc_updategamuseraccount__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_updategamuseraccount__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private string AV15Role ;
      private string GXt_char1 ;
      private bool AV14IsActive ;
      private string AV8GAMErrorResponse ;
      private string AV12UserGAMGUID ;
      private string AV10GivenName ;
      private string AV11LastName ;
      private string AV18PhoneCode ;
      private string AV20PhoneNumber ;
      private string AV22Profileimage_GXI ;
      private string AV19ProfileImage ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV9GAMUser ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV13GAMErrorCollection ;
      private IDataStoreProvider pr_default ;
      private string aP8_GAMErrorResponse ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class prc_updategamuseraccount__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class prc_updategamuseraccount__gam : DataStoreHelperBase, IDataStoreHelper
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

public class prc_updategamuseraccount__default : DataStoreHelperBase, IDataStoreHelper
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

}

}
