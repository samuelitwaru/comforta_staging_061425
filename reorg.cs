using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Reorg;
using System.Threading;
using GeneXus.Programs;
using System.Data;
using GeneXus.Data;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
namespace GeneXus.Programs {
   public class reorg : GXReorganization
   {
      public reorg( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", false);
      }

      public reorg( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         initialize();
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         SetCreateDataBase( ) ;
         CreateDataBase( ) ;
         if ( PreviousCheck() )
         {
            ExecuteReorganization( ) ;
         }
      }

      private void CreateDataBase( )
      {
         DS = (GxDataStore)(context.GetDataStore( "Default"));
         ErrCode = DS.Connection.FullConnect();
         DataBaseName = DS.Connection.Database;
         if ( ErrCode != 0 )
         {
            DS.Connection.Database = "postgres";
            ErrCode = DS.Connection.FullConnect();
            if ( ErrCode == 0 )
            {
               try
               {
                  GeneXus.Reorg.GXReorganization.AddMsg( GXResourceManager.GetMessage("GXM_dbcrea")+ " " +DataBaseName , null);
                  cmdBuffer = "CREATE DATABASE " + "\"" + DataBaseName + "\"";
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
                  Count = 1;
               }
               catch ( Exception ex )
               {
                  ErrCode = 1;
                  GeneXus.Reorg.GXReorganization.AddMsg( ex.Message , null);
                  throw;
               }
               ErrCode = DS.Connection.Disconnect();
               DS.Connection.Database = DataBaseName;
               ErrCode = DS.Connection.FullConnect();
               while ( ( ErrCode != 0 ) && ( Count > 0 ) && ( Count < 30 ) )
               {
                  Res = GXUtil.Sleep( 1);
                  ErrCode = DS.Connection.FullConnect();
                  Count = (short)(Count+1);
               }
            }
            if ( ErrCode != 0 )
            {
               ErrMsg = DS.ErrDescription;
               GeneXus.Reorg.GXReorganization.AddMsg( ErrMsg , null);
               ErrCode = 1;
               throw new Exception( ErrMsg) ;
            }
         }
      }

      private void FirstActions( )
      {
         /* Load data into tables. */
      }

      public void CreateTrn_EnvironmentVariable( )
      {
         string cmdBuffer = "";
         /* Indices for table Trn_EnvironmentVariable */
         try
         {
            cmdBuffer=" CREATE TABLE Trn_EnvironmentVariable (EnvironmentVariableId CHAR(36) NOT NULL , EnvironmentVariableKey VARCHAR(400) NOT NULL , EnvironmentVariableValue TEXT NOT NULL , PRIMARY KEY(EnvironmentVariableId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE Trn_EnvironmentVariable CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW Trn_EnvironmentVariable CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION Trn_EnvironmentVariable CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE Trn_EnvironmentVariable (EnvironmentVariableId CHAR(36) NOT NULL , EnvironmentVariableKey VARCHAR(400) NOT NULL , EnvironmentVariableValue TEXT NOT NULL , PRIMARY KEY(EnvironmentVariableId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE UNIQUE INDEX UTRN_ENVIRONMENTVARIABLE ON Trn_EnvironmentVariable (EnvironmentVariableKey ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX UTRN_ENVIRONMENTVARIABLE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE UNIQUE INDEX UTRN_ENVIRONMENTVARIABLE ON Trn_EnvironmentVariable (EnvironmentVariableKey ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateTrn_SupplierDynamicForm( )
      {
         string cmdBuffer = "";
         /* Indices for table Trn_SupplierDynamicForm */
         try
         {
            cmdBuffer=" CREATE TABLE Trn_SupplierDynamicForm (SupplierDynamicFormId CHAR(36) NOT NULL , SupplierGenId CHAR(36) NOT NULL , WWPFormId smallint NOT NULL , WWPFormVersionNumber smallint NOT NULL , PRIMARY KEY(SupplierDynamicFormId, SupplierGenId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE Trn_SupplierDynamicForm CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW Trn_SupplierDynamicForm CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION Trn_SupplierDynamicForm CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE Trn_SupplierDynamicForm (SupplierDynamicFormId CHAR(36) NOT NULL , SupplierGenId CHAR(36) NOT NULL , WWPFormId smallint NOT NULL , WWPFormVersionNumber smallint NOT NULL , PRIMARY KEY(SupplierDynamicFormId, SupplierGenId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ITRN_SUPPLIERDYNAMICFORM1 ON Trn_SupplierDynamicForm (WWPFormId ,WWPFormVersionNumber ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ITRN_SUPPLIERDYNAMICFORM1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ITRN_SUPPLIERDYNAMICFORM1 ON Trn_SupplierDynamicForm (WWPFormId ,WWPFormVersionNumber ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ITRN_SUPPLIERDYNAMICFORM2 ON Trn_SupplierDynamicForm (SupplierGenId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ITRN_SUPPLIERDYNAMICFORM2 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ITRN_SUPPLIERDYNAMICFORM2 ON Trn_SupplierDynamicForm (SupplierGenId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateTrn_LocationImage( )
      {
         string cmdBuffer = "";
         /* Indices for table Trn_LocationImage */
         try
         {
            cmdBuffer=" CREATE TABLE Trn_LocationImage (LocationImageId CHAR(36) NOT NULL , OrganisationLocationId CHAR(36) NOT NULL , OrganisationLocationImage BYTEA NOT NULL , OrganisationLocationImage_GXI VARCHAR(2048) , PRIMARY KEY(LocationImageId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE Trn_LocationImage CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW Trn_LocationImage CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION Trn_LocationImage CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE Trn_LocationImage (LocationImageId CHAR(36) NOT NULL , OrganisationLocationId CHAR(36) NOT NULL , OrganisationLocationImage BYTEA NOT NULL , OrganisationLocationImage_GXI VARCHAR(2048) , PRIMARY KEY(LocationImageId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateTrn_ServiceImage( )
      {
         string cmdBuffer = "";
         /* Indices for table Trn_ServiceImage */
         try
         {
            cmdBuffer=" CREATE TABLE Trn_ServiceImage (ServiceImageId CHAR(36) NOT NULL , ServiceId CHAR(36) NOT NULL , ServiceImage BYTEA NOT NULL , ServiceImage_GXI VARCHAR(2048) , PRIMARY KEY(ServiceImageId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE Trn_ServiceImage CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW Trn_ServiceImage CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION Trn_ServiceImage CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE Trn_ServiceImage (ServiceImageId CHAR(36) NOT NULL , ServiceId CHAR(36) NOT NULL , ServiceImage BYTEA NOT NULL , ServiceImage_GXI VARCHAR(2048) , PRIMARY KEY(ServiceImageId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX UTRN_SERVICEIMAGE ON Trn_ServiceImage (ServiceId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX UTRN_SERVICEIMAGE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX UTRN_SERVICEIMAGE ON Trn_ServiceImage (ServiceId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateTrn_DiscussionTranslation( )
      {
         string cmdBuffer = "";
         /* Indices for table Trn_DiscussionTranslation */
         try
         {
            cmdBuffer=" CREATE TABLE Trn_DiscussionTranslation (Trn_DiscussionTranslationId CHAR(36) NOT NULL , DiscussionTranslationWWPDiscus bigint NOT NULL , DiscussionTranslationEnglish VARCHAR(1000) NOT NULL , DiscussionTranslationDutch VARCHAR(1000) NOT NULL , PRIMARY KEY(Trn_DiscussionTranslationId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE Trn_DiscussionTranslation CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW Trn_DiscussionTranslation CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION Trn_DiscussionTranslation CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE Trn_DiscussionTranslation (Trn_DiscussionTranslationId CHAR(36) NOT NULL , DiscussionTranslationWWPDiscus bigint NOT NULL , DiscussionTranslationEnglish VARCHAR(1000) NOT NULL , DiscussionTranslationDutch VARCHAR(1000) NOT NULL , PRIMARY KEY(Trn_DiscussionTranslationId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX UTRN_DISCUSSIONTRANSLATION ON Trn_DiscussionTranslation (DiscussionTranslationWWPDiscus ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX UTRN_DISCUSSIONTRANSLATION "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX UTRN_DISCUSSIONTRANSLATION ON Trn_DiscussionTranslation (DiscussionTranslationWWPDiscus ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateTrn_DynamicFormTranslation( )
      {
         string cmdBuffer = "";
         /* Indices for table Trn_DynamicFormTranslation */
         try
         {
            cmdBuffer=" CREATE TABLE Trn_DynamicFormTranslation (DynamicFormTranslationId CHAR(36) NOT NULL , DynamicFormTranslationWWpFormI integer NOT NULL , DynamicFormTranslationWWPFormV integer NOT NULL , DynamicFormTranslationWWPFormE integer NOT NULL , DynamicFormTranslationTrnName VARCHAR(400) NOT NULL , DynamicFormTranslationAttribut VARCHAR(40) NOT NULL , DynamicFormTranslationEnglish TEXT NOT NULL , DynamicFormTranslationDutch TEXT NOT NULL , PRIMARY KEY(DynamicFormTranslationId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE Trn_DynamicFormTranslation CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW Trn_DynamicFormTranslation CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION Trn_DynamicFormTranslation CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE Trn_DynamicFormTranslation (DynamicFormTranslationId CHAR(36) NOT NULL , DynamicFormTranslationWWpFormI integer NOT NULL , DynamicFormTranslationWWPFormV integer NOT NULL , DynamicFormTranslationWWPFormE integer NOT NULL , DynamicFormTranslationTrnName VARCHAR(400) NOT NULL , DynamicFormTranslationAttribut VARCHAR(40) NOT NULL , DynamicFormTranslationEnglish TEXT NOT NULL , DynamicFormTranslationDutch TEXT NOT NULL , PRIMARY KEY(DynamicFormTranslationId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateTrn_DynamicTranslation( )
      {
         string cmdBuffer = "";
         /* Indices for table Trn_DynamicTranslation */
         try
         {
            cmdBuffer=" CREATE TABLE Trn_DynamicTranslation (DynamicTranslationId CHAR(36) NOT NULL , DynamicTranslationTrnName VARCHAR(100) NOT NULL , DynamicTranslationPrimaryKey CHAR(36) NOT NULL , DynamicTranslationAttributeNam VARCHAR(100) NOT NULL , DynamicTranslationEnglish TEXT NOT NULL , DynamicTranslationDutch TEXT NOT NULL , PRIMARY KEY(DynamicTranslationId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE Trn_DynamicTranslation CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW Trn_DynamicTranslation CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION Trn_DynamicTranslation CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE Trn_DynamicTranslation (DynamicTranslationId CHAR(36) NOT NULL , DynamicTranslationTrnName VARCHAR(100) NOT NULL , DynamicTranslationPrimaryKey CHAR(36) NOT NULL , DynamicTranslationAttributeNam VARCHAR(100) NOT NULL , DynamicTranslationEnglish TEXT NOT NULL , DynamicTranslationDutch TEXT NOT NULL , PRIMARY KEY(DynamicTranslationId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateTrn_Memo( )
      {
         string cmdBuffer = "";
         /* Indices for table Trn_Memo */
         try
         {
            cmdBuffer=" CREATE TABLE Trn_Memo (MemoId CHAR(36) NOT NULL , MemoTitle VARCHAR(100) NOT NULL , MemoDescription VARCHAR(200) NOT NULL , MemoImage TEXT , MemoDocument VARCHAR(200) , MemoStartDateTime timestamp without time zone , MemoEndDateTime timestamp without time zone , MemoDuration NUMERIC(5,3) , MemoRemoveDate date , ResidentId CHAR(36) NOT NULL , MemoBgColorCode VARCHAR(100) , MemoForm CHAR(20) NOT NULL , SG_OrganisationId CHAR(36) NOT NULL , SG_LocationId CHAR(36) NOT NULL , MemoType VARCHAR(100) NOT NULL , MemoName VARCHAR(100) NOT NULL , MemoLeftOffset NUMERIC(5,3) NOT NULL , MemoTopOffset NUMERIC(5,3) NOT NULL , MemoTitleAngle NUMERIC(5,3) NOT NULL , MemoTitleScale NUMERIC(5,3) NOT NULL , MemoTextFontName VARCHAR(100) NOT NULL , MemoTextAlignment CHAR(20) NOT NULL , MemoIsBold BOOLEAN NOT NULL , MemoIsItalic BOOLEAN NOT NULL , MemoIsCapitalized BOOLEAN NOT NULL , MemoTextColor VARCHAR(40) NOT NULL , PRIMARY KEY(MemoId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE Trn_Memo CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW Trn_Memo CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION Trn_Memo CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE Trn_Memo (MemoId CHAR(36) NOT NULL , MemoTitle VARCHAR(100) NOT NULL , MemoDescription VARCHAR(200) NOT NULL , MemoImage TEXT , MemoDocument VARCHAR(200) , MemoStartDateTime timestamp without time zone , MemoEndDateTime timestamp without time zone , MemoDuration NUMERIC(5,3) , MemoRemoveDate date , ResidentId CHAR(36) NOT NULL , MemoBgColorCode VARCHAR(100) , MemoForm CHAR(20) NOT NULL , SG_OrganisationId CHAR(36) NOT NULL , SG_LocationId CHAR(36) NOT NULL , MemoType VARCHAR(100) NOT NULL , MemoName VARCHAR(100) NOT NULL , MemoLeftOffset NUMERIC(5,3) NOT NULL , MemoTopOffset NUMERIC(5,3) NOT NULL , MemoTitleAngle NUMERIC(5,3) NOT NULL , MemoTitleScale NUMERIC(5,3) NOT NULL , MemoTextFontName VARCHAR(100) NOT NULL , MemoTextAlignment CHAR(20) NOT NULL , MemoIsBold BOOLEAN NOT NULL , MemoIsItalic BOOLEAN NOT NULL , MemoIsCapitalized BOOLEAN NOT NULL , MemoTextColor VARCHAR(40) NOT NULL , PRIMARY KEY(MemoId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ITRN_MEMO2 ON Trn_Memo (ResidentId ,SG_LocationId ,SG_OrganisationId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ITRN_MEMO2 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ITRN_MEMO2 ON Trn_Memo (ResidentId ,SG_LocationId ,SG_OrganisationId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateTrn_MemoCategory( )
      {
         string cmdBuffer = "";
         /* Indices for table Trn_MemoCategory */
         try
         {
            cmdBuffer=" CREATE TABLE Trn_MemoCategory (MemoCategoryId CHAR(36) NOT NULL , MemoCategoryName VARCHAR(100) NOT NULL , PRIMARY KEY(MemoCategoryId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE Trn_MemoCategory CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW Trn_MemoCategory CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION Trn_MemoCategory CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE Trn_MemoCategory (MemoCategoryId CHAR(36) NOT NULL , MemoCategoryName VARCHAR(100) NOT NULL , PRIMARY KEY(MemoCategoryId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateTrn_ThemeCtaColor( )
      {
         string cmdBuffer = "";
         /* Indices for table Trn_ThemeCtaColor */
         try
         {
            cmdBuffer=" CREATE TABLE Trn_ThemeCtaColor (Trn_ThemeId CHAR(36) NOT NULL , CtaColorId CHAR(36) NOT NULL , CtaColorName VARCHAR(100) NOT NULL , CtaColorCode VARCHAR(100) NOT NULL , PRIMARY KEY(Trn_ThemeId, CtaColorId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE Trn_ThemeCtaColor CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW Trn_ThemeCtaColor CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION Trn_ThemeCtaColor CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE Trn_ThemeCtaColor (Trn_ThemeId CHAR(36) NOT NULL , CtaColorId CHAR(36) NOT NULL , CtaColorName VARCHAR(100) NOT NULL , CtaColorCode VARCHAR(100) NOT NULL , PRIMARY KEY(Trn_ThemeId, CtaColorId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE UNIQUE INDEX UTRN_THEMECTACOLOR ON Trn_ThemeCtaColor (Trn_ThemeId ,CtaColorName ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX UTRN_THEMECTACOLOR "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE UNIQUE INDEX UTRN_THEMECTACOLOR ON Trn_ThemeCtaColor (Trn_ThemeId ,CtaColorName ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateTrn_ResidentPackage( )
      {
         string cmdBuffer = "";
         /* Indices for table Trn_ResidentPackage */
         try
         {
            cmdBuffer=" CREATE TABLE Trn_ResidentPackage (ResidentPackageId CHAR(36) NOT NULL , SG_LocationId CHAR(36) NOT NULL , SG_OrganisationId CHAR(36) NOT NULL , ResidentPackageName VARCHAR(100) NOT NULL , ResidentPackageModules TEXT NOT NULL , ResidentPackageDefault BOOLEAN NOT NULL , PRIMARY KEY(ResidentPackageId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE Trn_ResidentPackage CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW Trn_ResidentPackage CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION Trn_ResidentPackage CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE Trn_ResidentPackage (ResidentPackageId CHAR(36) NOT NULL , SG_LocationId CHAR(36) NOT NULL , SG_OrganisationId CHAR(36) NOT NULL , ResidentPackageName VARCHAR(100) NOT NULL , ResidentPackageModules TEXT NOT NULL , ResidentPackageDefault BOOLEAN NOT NULL , PRIMARY KEY(ResidentPackageId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ITRN_RESIDENTPACKAGE1 ON Trn_ResidentPackage (SG_LocationId ,SG_OrganisationId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ITRN_RESIDENTPACKAGE1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ITRN_RESIDENTPACKAGE1 ON Trn_ResidentPackage (SG_LocationId ,SG_OrganisationId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateTrn_AppVersionPage( )
      {
         string cmdBuffer = "";
         /* Indices for table Trn_AppVersionPage */
         try
         {
            cmdBuffer=" CREATE TABLE Trn_AppVersionPage (AppVersionId CHAR(36) NOT NULL , PageId CHAR(36) NOT NULL , PageType VARCHAR(40) NOT NULL , PageName VARCHAR(100) NOT NULL , PageStructure TEXT NOT NULL , PagePublishedStructure TEXT NOT NULL , IsPredefined BOOLEAN NOT NULL , PageThumbnail BYTEA , PageThumbnail_GXI VARCHAR(2048) , IsPageDeleted BOOLEAN NOT NULL , PageDeletedAt timestamp without time zone , PRIMARY KEY(AppVersionId, PageId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE Trn_AppVersionPage CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW Trn_AppVersionPage CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION Trn_AppVersionPage CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE Trn_AppVersionPage (AppVersionId CHAR(36) NOT NULL , PageId CHAR(36) NOT NULL , PageType VARCHAR(40) NOT NULL , PageName VARCHAR(100) NOT NULL , PageStructure TEXT NOT NULL , PagePublishedStructure TEXT NOT NULL , IsPredefined BOOLEAN NOT NULL , PageThumbnail BYTEA , PageThumbnail_GXI VARCHAR(2048) , IsPageDeleted BOOLEAN NOT NULL , PageDeletedAt timestamp without time zone , PRIMARY KEY(AppVersionId, PageId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateTrn_AppVersion( )
      {
         string cmdBuffer = "";
         /* Indices for table Trn_AppVersion */
         try
         {
            cmdBuffer=" CREATE TABLE Trn_AppVersion (AppVersionId CHAR(36) NOT NULL , AppVersionName VARCHAR(100) NOT NULL , LocationId CHAR(36) , IsActive BOOLEAN NOT NULL , OrganisationId CHAR(36) , IsVersionDeleted BOOLEAN NOT NULL , VersionDeletedAt timestamp without time zone , Trn_ThemeId CHAR(36) NOT NULL , PRIMARY KEY(AppVersionId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE Trn_AppVersion CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW Trn_AppVersion CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION Trn_AppVersion CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE Trn_AppVersion (AppVersionId CHAR(36) NOT NULL , AppVersionName VARCHAR(100) NOT NULL , LocationId CHAR(36) , IsActive BOOLEAN NOT NULL , OrganisationId CHAR(36) , IsVersionDeleted BOOLEAN NOT NULL , VersionDeletedAt timestamp without time zone , Trn_ThemeId CHAR(36) NOT NULL , PRIMARY KEY(AppVersionId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ITRN_APPVERSION1 ON Trn_AppVersion (LocationId ,OrganisationId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ITRN_APPVERSION1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ITRN_APPVERSION1 ON Trn_AppVersion (LocationId ,OrganisationId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ITRN_APPVERSION2 ON Trn_AppVersion (Trn_ThemeId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ITRN_APPVERSION2 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ITRN_APPVERSION2 ON Trn_AppVersion (Trn_ThemeId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateTrn_OrganisationSetting( )
      {
         string cmdBuffer = "";
         /* Indices for table Trn_OrganisationSetting */
         try
         {
            cmdBuffer=" CREATE TABLE Trn_OrganisationSetting (OrganisationSettingid CHAR(36) NOT NULL , OrganisationId CHAR(36) NOT NULL , OrganisationSettingLogo BYTEA NOT NULL , OrganisationSettingLogo_GXI VARCHAR(2048) , OrganisationSettingFavicon BYTEA NOT NULL , OrganisationSettingFavicon_GXI VARCHAR(2048) , OrganisationSettingBaseColor VARCHAR(40) NOT NULL , OrganisationSettingFontSize VARCHAR(40) NOT NULL , OrganisationSettingLanguage TEXT NOT NULL , OrganisationHasMyCare BOOLEAN NOT NULL , OrganisationHasMyLiving BOOLEAN NOT NULL , OrganisationHasMyServices BOOLEAN NOT NULL , OrganisationHasDynamicForms BOOLEAN NOT NULL , OrganisationBrandTheme TEXT NOT NULL , OrganisationCtaTheme TEXT NOT NULL , OrganisationHasOwnBrand BOOLEAN NOT NULL , Trn_ThemeId CHAR(36) , OrganisationDefinitions TEXT , PRIMARY KEY(OrganisationSettingid, OrganisationId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE Trn_OrganisationSetting CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW Trn_OrganisationSetting CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION Trn_OrganisationSetting CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE Trn_OrganisationSetting (OrganisationSettingid CHAR(36) NOT NULL , OrganisationId CHAR(36) NOT NULL , OrganisationSettingLogo BYTEA NOT NULL , OrganisationSettingLogo_GXI VARCHAR(2048) , OrganisationSettingFavicon BYTEA NOT NULL , OrganisationSettingFavicon_GXI VARCHAR(2048) , OrganisationSettingBaseColor VARCHAR(40) NOT NULL , OrganisationSettingFontSize VARCHAR(40) NOT NULL , OrganisationSettingLanguage TEXT NOT NULL , OrganisationHasMyCare BOOLEAN NOT NULL , OrganisationHasMyLiving BOOLEAN NOT NULL , OrganisationHasMyServices BOOLEAN NOT NULL , OrganisationHasDynamicForms BOOLEAN NOT NULL , OrganisationBrandTheme TEXT NOT NULL , OrganisationCtaTheme TEXT NOT NULL , OrganisationHasOwnBrand BOOLEAN NOT NULL , Trn_ThemeId CHAR(36) , OrganisationDefinitions TEXT , PRIMARY KEY(OrganisationSettingid, OrganisationId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ITRN_ORGANISATIONSETTING1 ON Trn_OrganisationSetting (OrganisationId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ITRN_ORGANISATIONSETTING1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ITRN_ORGANISATIONSETTING1 ON Trn_OrganisationSetting (OrganisationId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ITRN_ORGANISATIONSETTING2 ON Trn_OrganisationSetting (Trn_ThemeId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ITRN_ORGANISATIONSETTING2 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ITRN_ORGANISATIONSETTING2 ON Trn_OrganisationSetting (Trn_ThemeId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateTrn_OrganisationDynamicForm( )
      {
         string cmdBuffer = "";
         /* Indices for table Trn_OrganisationDynamicForm */
         try
         {
            cmdBuffer=" CREATE TABLE Trn_OrganisationDynamicForm (OrganisationDynamicFormId CHAR(36) NOT NULL , OrganisationId CHAR(36) NOT NULL , WWPFormId smallint NOT NULL , WWPFormVersionNumber smallint NOT NULL , PRIMARY KEY(OrganisationDynamicFormId, OrganisationId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE Trn_OrganisationDynamicForm CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW Trn_OrganisationDynamicForm CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION Trn_OrganisationDynamicForm CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE Trn_OrganisationDynamicForm (OrganisationDynamicFormId CHAR(36) NOT NULL , OrganisationId CHAR(36) NOT NULL , WWPFormId smallint NOT NULL , WWPFormVersionNumber smallint NOT NULL , PRIMARY KEY(OrganisationDynamicFormId, OrganisationId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ITRN_ORGANISATIONDYNAMICFORM1 ON Trn_OrganisationDynamicForm (WWPFormId ,WWPFormVersionNumber ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ITRN_ORGANISATIONDYNAMICFORM1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ITRN_ORGANISATIONDYNAMICFORM1 ON Trn_OrganisationDynamicForm (WWPFormId ,WWPFormVersionNumber ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ITRN_ORGANISATIONDYNAMICFORM2 ON Trn_OrganisationDynamicForm (OrganisationId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ITRN_ORGANISATIONDYNAMICFORM2 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ITRN_ORGANISATIONDYNAMICFORM2 ON Trn_OrganisationDynamicForm (OrganisationId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateTrn_Page( )
      {
         string cmdBuffer = "";
         /* Indices for table Trn_Page */
         try
         {
            cmdBuffer=" CREATE TABLE Trn_Page (Trn_PageId CHAR(36) NOT NULL , LocationId CHAR(36) NOT NULL , Trn_PageName VARCHAR(100) NOT NULL , PageJsonContent TEXT , PageGJSHtml TEXT , PageGJSJson TEXT , PageIsPublished BOOLEAN , PageIsPredefined BOOLEAN NOT NULL , PageIsContentPage BOOLEAN , PageIsDynamicForm BOOLEAN NOT NULL , PageIsWebLinkPage BOOLEAN NOT NULL , PageChildren TEXT , ProductServiceId CHAR(36) , OrganisationId CHAR(36) NOT NULL , PRIMARY KEY(Trn_PageId, LocationId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE Trn_Page CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW Trn_Page CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION Trn_Page CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE Trn_Page (Trn_PageId CHAR(36) NOT NULL , LocationId CHAR(36) NOT NULL , Trn_PageName VARCHAR(100) NOT NULL , PageJsonContent TEXT , PageGJSHtml TEXT , PageGJSJson TEXT , PageIsPublished BOOLEAN , PageIsPredefined BOOLEAN NOT NULL , PageIsContentPage BOOLEAN , PageIsDynamicForm BOOLEAN NOT NULL , PageIsWebLinkPage BOOLEAN NOT NULL , PageChildren TEXT , ProductServiceId CHAR(36) , OrganisationId CHAR(36) NOT NULL , PRIMARY KEY(Trn_PageId, LocationId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ITRN_PAGE1 ON Trn_Page (ProductServiceId ,LocationId ,OrganisationId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ITRN_PAGE1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ITRN_PAGE1 ON Trn_Page (ProductServiceId ,LocationId ,OrganisationId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateTrn_ResidentNotification( )
      {
         string cmdBuffer = "";
         /* Indices for table Trn_ResidentNotification */
         try
         {
            cmdBuffer=" CREATE TABLE Trn_ResidentNotification (ResidentNotificationId CHAR(36) NOT NULL , AppNotificationId CHAR(36) NOT NULL , ResidentId CHAR(36) NOT NULL , PRIMARY KEY(ResidentNotificationId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE Trn_ResidentNotification CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW Trn_ResidentNotification CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION Trn_ResidentNotification CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE Trn_ResidentNotification (ResidentNotificationId CHAR(36) NOT NULL , AppNotificationId CHAR(36) NOT NULL , ResidentId CHAR(36) NOT NULL , PRIMARY KEY(ResidentNotificationId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ITRN_RESIDENTNOTIFICATION1 ON Trn_ResidentNotification (AppNotificationId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ITRN_RESIDENTNOTIFICATION1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ITRN_RESIDENTNOTIFICATION1 ON Trn_ResidentNotification (AppNotificationId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateTrn_AppNotification( )
      {
         string cmdBuffer = "";
         /* Indices for table Trn_AppNotification */
         try
         {
            cmdBuffer=" CREATE TABLE Trn_AppNotification (AppNotificationId CHAR(36) NOT NULL , AppNotificationTitle VARCHAR(100) NOT NULL , AppNotificationDescription VARCHAR(200) NOT NULL , AppNotificationDate timestamp without time zone NOT NULL , AppNotificationTopic VARCHAR(100) NOT NULL , AppNotificationMetadata TEXT , PRIMARY KEY(AppNotificationId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE Trn_AppNotification CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW Trn_AppNotification CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION Trn_AppNotification CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE Trn_AppNotification (AppNotificationId CHAR(36) NOT NULL , AppNotificationTitle VARCHAR(100) NOT NULL , AppNotificationDescription VARCHAR(200) NOT NULL , AppNotificationDate timestamp without time zone NOT NULL , AppNotificationTopic VARCHAR(100) NOT NULL , AppNotificationMetadata TEXT , PRIMARY KEY(AppNotificationId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX UTRN_APPNOTIFICATION ON Trn_AppNotification (AppNotificationDate DESC) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX UTRN_APPNOTIFICATION "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX UTRN_APPNOTIFICATION ON Trn_AppNotification (AppNotificationDate DESC) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateTrn_AgendaEventGroup( )
      {
         string cmdBuffer = "";
         /* Indices for table Trn_AgendaEventGroup */
         try
         {
            cmdBuffer=" CREATE TABLE Trn_AgendaEventGroup (AgendaCalendarId CHAR(36) NOT NULL , ResidentId CHAR(36) NOT NULL , AgendaEventGroupRSVP BOOLEAN NOT NULL , PRIMARY KEY(AgendaCalendarId, ResidentId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE Trn_AgendaEventGroup CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW Trn_AgendaEventGroup CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION Trn_AgendaEventGroup CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE Trn_AgendaEventGroup (AgendaCalendarId CHAR(36) NOT NULL , ResidentId CHAR(36) NOT NULL , AgendaEventGroupRSVP BOOLEAN NOT NULL , PRIMARY KEY(AgendaCalendarId, ResidentId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateTrn_ThemeIcon( )
      {
         string cmdBuffer = "";
         /* Indices for table Trn_ThemeIcon */
         try
         {
            cmdBuffer=" CREATE TABLE Trn_ThemeIcon (Trn_ThemeId CHAR(36) NOT NULL , IconId CHAR(36) NOT NULL , IconName VARCHAR(100) NOT NULL , IconSVG TEXT NOT NULL , IconCategory VARCHAR(40) NOT NULL , PRIMARY KEY(Trn_ThemeId, IconId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE Trn_ThemeIcon CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW Trn_ThemeIcon CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION Trn_ThemeIcon CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE Trn_ThemeIcon (Trn_ThemeId CHAR(36) NOT NULL , IconId CHAR(36) NOT NULL , IconName VARCHAR(100) NOT NULL , IconSVG TEXT NOT NULL , IconCategory VARCHAR(40) NOT NULL , PRIMARY KEY(Trn_ThemeId, IconId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE UNIQUE INDEX UTRN_THEMEICON ON Trn_ThemeIcon (Trn_ThemeId ,IconName ,IconCategory ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX UTRN_THEMEICON "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE UNIQUE INDEX UTRN_THEMEICON ON Trn_ThemeIcon (Trn_ThemeId ,IconName ,IconCategory ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateTrn_Media( )
      {
         string cmdBuffer = "";
         /* Indices for table Trn_Media */
         try
         {
            cmdBuffer=" CREATE TABLE Trn_Media (MediaId CHAR(36) NOT NULL , MediaName VARCHAR(100) NOT NULL , MediaImage BYTEA , MediaImage_GXI VARCHAR(2048) , MediaSize integer NOT NULL , MediaType CHAR(20) NOT NULL , MediaUrl VARCHAR(1000) NOT NULL , LocationId CHAR(36) NOT NULL , MediaDateTime timestamp without time zone , IsCropped BOOLEAN NOT NULL , PRIMARY KEY(MediaId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE Trn_Media CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW Trn_Media CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION Trn_Media CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE Trn_Media (MediaId CHAR(36) NOT NULL , MediaName VARCHAR(100) NOT NULL , MediaImage BYTEA , MediaImage_GXI VARCHAR(2048) , MediaSize integer NOT NULL , MediaType CHAR(20) NOT NULL , MediaUrl VARCHAR(1000) NOT NULL , LocationId CHAR(36) NOT NULL , MediaDateTime timestamp without time zone , IsCropped BOOLEAN NOT NULL , PRIMARY KEY(MediaId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateTrn_PreferredGenSupplier( )
      {
         string cmdBuffer = "";
         /* Indices for table Trn_PreferredGenSupplier */
         try
         {
            cmdBuffer=" CREATE TABLE Trn_PreferredGenSupplier (PreferredGenSupplierId CHAR(36) NOT NULL , PreferredGenOrganisationId CHAR(36) NOT NULL , PreferredSupplierGenId CHAR(36) NOT NULL , PRIMARY KEY(PreferredGenSupplierId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE Trn_PreferredGenSupplier CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW Trn_PreferredGenSupplier CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION Trn_PreferredGenSupplier CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE Trn_PreferredGenSupplier (PreferredGenSupplierId CHAR(36) NOT NULL , PreferredGenOrganisationId CHAR(36) NOT NULL , PreferredSupplierGenId CHAR(36) NOT NULL , PRIMARY KEY(PreferredGenSupplierId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateTrn_PreferredAgbSupplier( )
      {
         string cmdBuffer = "";
         /* Indices for table Trn_PreferredAgbSupplier */
         try
         {
            cmdBuffer=" CREATE TABLE Trn_PreferredAgbSupplier (PreferredAgbSupplierId CHAR(36) NOT NULL , PreferredAgbOrganisationId CHAR(36) NOT NULL , PreferredSupplierAgbId CHAR(36) NOT NULL , PRIMARY KEY(PreferredAgbSupplierId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE Trn_PreferredAgbSupplier CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW Trn_PreferredAgbSupplier CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION Trn_PreferredAgbSupplier CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE Trn_PreferredAgbSupplier (PreferredAgbSupplierId CHAR(36) NOT NULL , PreferredAgbOrganisationId CHAR(36) NOT NULL , PreferredSupplierAgbId CHAR(36) NOT NULL , PRIMARY KEY(PreferredAgbSupplierId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateTrn_Audit( )
      {
         string cmdBuffer = "";
         /* Indices for table Trn_Audit */
         try
         {
            cmdBuffer=" CREATE TABLE Trn_Audit (AuditId CHAR(36) NOT NULL , AuditDate timestamp without time zone NOT NULL , AuditTableName VARCHAR(100) NOT NULL , AuditDescription TEXT NOT NULL , AuditShortDescription VARCHAR(400) NOT NULL , GAMUserId CHAR(40) NOT NULL , AuditUserName VARCHAR(100) NOT NULL , AuditAction VARCHAR(40) NOT NULL , OrganisationId CHAR(36) , PRIMARY KEY(AuditId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE Trn_Audit CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW Trn_Audit CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION Trn_Audit CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE Trn_Audit (AuditId CHAR(36) NOT NULL , AuditDate timestamp without time zone NOT NULL , AuditTableName VARCHAR(100) NOT NULL , AuditDescription TEXT NOT NULL , AuditShortDescription VARCHAR(400) NOT NULL , GAMUserId CHAR(40) NOT NULL , AuditUserName VARCHAR(100) NOT NULL , AuditAction VARCHAR(40) NOT NULL , OrganisationId CHAR(36) , PRIMARY KEY(AuditId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ITRN_AUDIT ON Trn_Audit (OrganisationId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ITRN_AUDIT "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ITRN_AUDIT ON Trn_Audit (OrganisationId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateTrn_CallToAction( )
      {
         string cmdBuffer = "";
         /* Indices for table Trn_CallToAction */
         try
         {
            cmdBuffer=" CREATE TABLE Trn_CallToAction (CallToActionId CHAR(36) NOT NULL , ProductServiceId CHAR(36) NOT NULL , OrganisationId CHAR(36) NOT NULL , LocationId CHAR(36) NOT NULL , CallToActionName VARCHAR(100) NOT NULL , CallToActionType VARCHAR(100) NOT NULL , CallToActionPhone CHAR(20) NOT NULL , CallToActionUrl VARCHAR(1000) NOT NULL , CallToActionEmail VARCHAR(100) NOT NULL , LocationDynamicFormId CHAR(36) , CallToActionPhoneCode VARCHAR(40) NOT NULL , CallToActionPhoneNumber VARCHAR(9) NOT NULL , PRIMARY KEY(CallToActionId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE Trn_CallToAction CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW Trn_CallToAction CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION Trn_CallToAction CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE Trn_CallToAction (CallToActionId CHAR(36) NOT NULL , ProductServiceId CHAR(36) NOT NULL , OrganisationId CHAR(36) NOT NULL , LocationId CHAR(36) NOT NULL , CallToActionName VARCHAR(100) NOT NULL , CallToActionType VARCHAR(100) NOT NULL , CallToActionPhone CHAR(20) NOT NULL , CallToActionUrl VARCHAR(1000) NOT NULL , CallToActionEmail VARCHAR(100) NOT NULL , LocationDynamicFormId CHAR(36) , CallToActionPhoneCode VARCHAR(40) NOT NULL , CallToActionPhoneNumber VARCHAR(9) NOT NULL , PRIMARY KEY(CallToActionId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ITRN_CALLTOACTION1 ON Trn_CallToAction (LocationDynamicFormId ,OrganisationId ,LocationId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ITRN_CALLTOACTION1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ITRN_CALLTOACTION1 ON Trn_CallToAction (LocationDynamicFormId ,OrganisationId ,LocationId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ITRN_CALLTOACTION2 ON Trn_CallToAction (ProductServiceId ,LocationId ,OrganisationId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ITRN_CALLTOACTION2 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ITRN_CALLTOACTION2 ON Trn_CallToAction (ProductServiceId ,LocationId ,OrganisationId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateTrn_LocationDynamicForm( )
      {
         string cmdBuffer = "";
         /* Indices for table Trn_LocationDynamicForm */
         try
         {
            cmdBuffer=" CREATE TABLE Trn_LocationDynamicForm (LocationDynamicFormId CHAR(36) NOT NULL , OrganisationId CHAR(36) NOT NULL , LocationId CHAR(36) NOT NULL , WWPFormId smallint NOT NULL , WWPFormVersionNumber smallint NOT NULL , FormPageName VARCHAR(100) NOT NULL , PRIMARY KEY(LocationDynamicFormId, OrganisationId, LocationId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE Trn_LocationDynamicForm CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW Trn_LocationDynamicForm CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION Trn_LocationDynamicForm CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE Trn_LocationDynamicForm (LocationDynamicFormId CHAR(36) NOT NULL , OrganisationId CHAR(36) NOT NULL , LocationId CHAR(36) NOT NULL , WWPFormId smallint NOT NULL , WWPFormVersionNumber smallint NOT NULL , FormPageName VARCHAR(100) NOT NULL , PRIMARY KEY(LocationDynamicFormId, OrganisationId, LocationId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ITRN_LOCATIONDYNAMICFORM1 ON Trn_LocationDynamicForm (WWPFormId ,WWPFormVersionNumber ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ITRN_LOCATIONDYNAMICFORM1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ITRN_LOCATIONDYNAMICFORM1 ON Trn_LocationDynamicForm (WWPFormId ,WWPFormVersionNumber ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ITRN_LOCATIONDYNAMICFORM2 ON Trn_LocationDynamicForm (LocationId ,OrganisationId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ITRN_LOCATIONDYNAMICFORM2 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ITRN_LOCATIONDYNAMICFORM2 ON Trn_LocationDynamicForm (LocationId ,OrganisationId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateTrn_ProductService( )
      {
         string cmdBuffer = "";
         /* Indices for table Trn_ProductService */
         try
         {
            cmdBuffer=" CREATE TABLE Trn_ProductService (ProductServiceId CHAR(36) NOT NULL , LocationId CHAR(36) NOT NULL , OrganisationId CHAR(36) NOT NULL , ProductServiceName VARCHAR(100) NOT NULL , ProductServiceTileName CHAR(20) NOT NULL , ProductServiceDescription TEXT NOT NULL , ProductServiceImage BYTEA NOT NULL , ProductServiceImage_GXI VARCHAR(2048) , ProductServiceGroup VARCHAR(400) NOT NULL , SupplierGenId CHAR(36) , SupplierAgbId CHAR(36) , ProductServiceClass VARCHAR(400) NOT NULL , PRIMARY KEY(ProductServiceId, LocationId, OrganisationId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE Trn_ProductService CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW Trn_ProductService CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION Trn_ProductService CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE Trn_ProductService (ProductServiceId CHAR(36) NOT NULL , LocationId CHAR(36) NOT NULL , OrganisationId CHAR(36) NOT NULL , ProductServiceName VARCHAR(100) NOT NULL , ProductServiceTileName CHAR(20) NOT NULL , ProductServiceDescription TEXT NOT NULL , ProductServiceImage BYTEA NOT NULL , ProductServiceImage_GXI VARCHAR(2048) , ProductServiceGroup VARCHAR(400) NOT NULL , SupplierGenId CHAR(36) , SupplierAgbId CHAR(36) , ProductServiceClass VARCHAR(400) NOT NULL , PRIMARY KEY(ProductServiceId, LocationId, OrganisationId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ITRN_PRODUCTSERVICE1 ON Trn_ProductService (SupplierAgbId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ITRN_PRODUCTSERVICE1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ITRN_PRODUCTSERVICE1 ON Trn_ProductService (SupplierAgbId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ITRN_PRODUCTSERVICE2 ON Trn_ProductService (SupplierGenId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ITRN_PRODUCTSERVICE2 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ITRN_PRODUCTSERVICE2 ON Trn_ProductService (SupplierGenId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ITRN_PRODUCTSERVICE3 ON Trn_ProductService (LocationId ,OrganisationId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ITRN_PRODUCTSERVICE3 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ITRN_PRODUCTSERVICE3 ON Trn_ProductService (LocationId ,OrganisationId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX UTRN_PRODUCTSERVICE ON Trn_ProductService (ProductServiceName ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX UTRN_PRODUCTSERVICE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX UTRN_PRODUCTSERVICE ON Trn_ProductService (ProductServiceName ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateTrn_Device( )
      {
         string cmdBuffer = "";
         /* Indices for table Trn_Device */
         try
         {
            cmdBuffer=" CREATE TABLE Trn_Device (DeviceId CHAR(128) NOT NULL , DeviceType smallint NOT NULL , DeviceToken CHAR(1000) NOT NULL , DeviceName CHAR(128) NOT NULL , DeviceUserId VARCHAR(100) NOT NULL , PRIMARY KEY(DeviceId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE Trn_Device CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW Trn_Device CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION Trn_Device CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE Trn_Device (DeviceId CHAR(128) NOT NULL , DeviceType smallint NOT NULL , DeviceToken CHAR(1000) NOT NULL , DeviceName CHAR(128) NOT NULL , DeviceUserId VARCHAR(100) NOT NULL , PRIMARY KEY(DeviceId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX UTRN_DEVICE ON Trn_Device (DeviceType ,DeviceId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX UTRN_DEVICE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX UTRN_DEVICE ON Trn_Device (DeviceType ,DeviceId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateTrn_Resident( )
      {
         string cmdBuffer = "";
         /* Indices for table Trn_Resident */
         try
         {
            cmdBuffer=" CREATE TABLE Trn_Resident (ResidentId CHAR(36) NOT NULL , LocationId CHAR(36) NOT NULL , OrganisationId CHAR(36) NOT NULL , ResidentSalutation CHAR(20) NOT NULL , ResidentBsnNumber VARCHAR(9) NOT NULL , ResidentGivenName VARCHAR(100) NOT NULL , ResidentLastName VARCHAR(100) NOT NULL , ResidentInitials CHAR(20) NOT NULL , ResidentEmail VARCHAR(100) NOT NULL , ResidentGender VARCHAR(40) NOT NULL , ResidentCountry VARCHAR(100) NOT NULL , ResidentCity VARCHAR(100) NOT NULL , ResidentZipCode VARCHAR(100) NOT NULL , ResidentAddressLine1 VARCHAR(100) NOT NULL , ResidentAddressLine2 VARCHAR(100) NOT NULL , ResidentPhone CHAR(20) NOT NULL , ResidentBirthDate date NOT NULL , ResidentGUID VARCHAR(100) NOT NULL , ResidentTypeId CHAR(36) , MedicalIndicationId CHAR(36) , ResidentPhoneCode VARCHAR(40) NOT NULL , ResidentPhoneNumber VARCHAR(9) NOT NULL , ResidentHomePhone CHAR(20) NOT NULL , ResidentHomePhoneCode VARCHAR(40) NOT NULL , ResidentHomePhoneNumber VARCHAR(9) NOT NULL , ResidentImage BYTEA , ResidentImage_GXI VARCHAR(2048) , ResidentPackageId CHAR(36) , ResidentLanguage CHAR(20) NOT NULL , PRIMARY KEY(ResidentId, LocationId, OrganisationId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE Trn_Resident CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW Trn_Resident CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION Trn_Resident CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE Trn_Resident (ResidentId CHAR(36) NOT NULL , LocationId CHAR(36) NOT NULL , OrganisationId CHAR(36) NOT NULL , ResidentSalutation CHAR(20) NOT NULL , ResidentBsnNumber VARCHAR(9) NOT NULL , ResidentGivenName VARCHAR(100) NOT NULL , ResidentLastName VARCHAR(100) NOT NULL , ResidentInitials CHAR(20) NOT NULL , ResidentEmail VARCHAR(100) NOT NULL , ResidentGender VARCHAR(40) NOT NULL , ResidentCountry VARCHAR(100) NOT NULL , ResidentCity VARCHAR(100) NOT NULL , ResidentZipCode VARCHAR(100) NOT NULL , ResidentAddressLine1 VARCHAR(100) NOT NULL , ResidentAddressLine2 VARCHAR(100) NOT NULL , ResidentPhone CHAR(20) NOT NULL , ResidentBirthDate date NOT NULL , ResidentGUID VARCHAR(100) NOT NULL , ResidentTypeId CHAR(36) , MedicalIndicationId CHAR(36) , ResidentPhoneCode VARCHAR(40) NOT NULL , ResidentPhoneNumber VARCHAR(9) NOT NULL , ResidentHomePhone CHAR(20) NOT NULL , ResidentHomePhoneCode VARCHAR(40) NOT NULL , ResidentHomePhoneNumber VARCHAR(9) NOT NULL , ResidentImage BYTEA , ResidentImage_GXI VARCHAR(2048) , ResidentPackageId CHAR(36) , ResidentLanguage CHAR(20) NOT NULL , PRIMARY KEY(ResidentId, LocationId, OrganisationId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ITRN_RESIDENT2 ON Trn_Resident (MedicalIndicationId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ITRN_RESIDENT2 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ITRN_RESIDENT2 ON Trn_Resident (MedicalIndicationId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ITRN_RESIDENT3 ON Trn_Resident (ResidentTypeId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ITRN_RESIDENT3 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ITRN_RESIDENT3 ON Trn_Resident (ResidentTypeId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ITRN_RESIDENT4 ON Trn_Resident (LocationId ,OrganisationId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ITRN_RESIDENT4 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ITRN_RESIDENT4 ON Trn_Resident (LocationId ,OrganisationId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX UTRN_RESIDENT ON Trn_Resident (OrganisationId ,LocationId ,ResidentId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX UTRN_RESIDENT "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX UTRN_RESIDENT ON Trn_Resident (OrganisationId ,LocationId ,ResidentId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ITRN_RESIDENT1 ON Trn_Resident (ResidentPackageId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ITRN_RESIDENT1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ITRN_RESIDENT1 ON Trn_Resident (ResidentPackageId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateTrn_Receptionist( )
      {
         string cmdBuffer = "";
         /* Indices for table Trn_Receptionist */
         try
         {
            cmdBuffer=" CREATE TABLE Trn_Receptionist (ReceptionistId CHAR(36) NOT NULL , OrganisationId CHAR(36) NOT NULL , LocationId CHAR(36) NOT NULL , ReceptionistGivenName VARCHAR(100) NOT NULL , ReceptionistLastName VARCHAR(100) NOT NULL , ReceptionistInitials CHAR(20) NOT NULL , ReceptionistEmail VARCHAR(100) NOT NULL , ReceptionistPhone CHAR(20) NOT NULL , ReceptionistGAMGUID VARCHAR(100) NOT NULL , ReceptionistPhoneCode VARCHAR(40) NOT NULL , ReceptionistPhoneNumber VARCHAR(9) NOT NULL , ReceptionistIsActive BOOLEAN NOT NULL , ReceptionistImage BYTEA NOT NULL , ReceptionistImage_GXI VARCHAR(2048) , PRIMARY KEY(ReceptionistId, OrganisationId, LocationId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE Trn_Receptionist CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW Trn_Receptionist CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION Trn_Receptionist CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE Trn_Receptionist (ReceptionistId CHAR(36) NOT NULL , OrganisationId CHAR(36) NOT NULL , LocationId CHAR(36) NOT NULL , ReceptionistGivenName VARCHAR(100) NOT NULL , ReceptionistLastName VARCHAR(100) NOT NULL , ReceptionistInitials CHAR(20) NOT NULL , ReceptionistEmail VARCHAR(100) NOT NULL , ReceptionistPhone CHAR(20) NOT NULL , ReceptionistGAMGUID VARCHAR(100) NOT NULL , ReceptionistPhoneCode VARCHAR(40) NOT NULL , ReceptionistPhoneNumber VARCHAR(9) NOT NULL , ReceptionistIsActive BOOLEAN NOT NULL , ReceptionistImage BYTEA NOT NULL , ReceptionistImage_GXI VARCHAR(2048) , PRIMARY KEY(ReceptionistId, OrganisationId, LocationId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ITRN_RECEPTIONIST1 ON Trn_Receptionist (LocationId ,OrganisationId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ITRN_RECEPTIONIST1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ITRN_RECEPTIONIST1 ON Trn_Receptionist (LocationId ,OrganisationId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateTrn_Template( )
      {
         string cmdBuffer = "";
         /* Indices for table Trn_Template */
         try
         {
            cmdBuffer=" CREATE TABLE Trn_Template (Trn_TemplateId CHAR(36) NOT NULL , Trn_TemplateName VARCHAR(100) NOT NULL , Trn_TemplateMedia VARCHAR(100) NOT NULL , Trn_TemplateContent TEXT NOT NULL , PRIMARY KEY(Trn_TemplateId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE Trn_Template CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW Trn_Template CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION Trn_Template CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE Trn_Template (Trn_TemplateId CHAR(36) NOT NULL , Trn_TemplateName VARCHAR(100) NOT NULL , Trn_TemplateMedia VARCHAR(100) NOT NULL , Trn_TemplateContent TEXT NOT NULL , PRIMARY KEY(Trn_TemplateId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateTrn_ThemeColor( )
      {
         string cmdBuffer = "";
         /* Indices for table Trn_ThemeColor */
         try
         {
            cmdBuffer=" CREATE TABLE Trn_ThemeColor (Trn_ThemeId CHAR(36) NOT NULL , ColorId CHAR(36) NOT NULL , ColorName VARCHAR(100) NOT NULL , ColorCode VARCHAR(100) NOT NULL , PRIMARY KEY(Trn_ThemeId, ColorId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE Trn_ThemeColor CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW Trn_ThemeColor CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION Trn_ThemeColor CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE Trn_ThemeColor (Trn_ThemeId CHAR(36) NOT NULL , ColorId CHAR(36) NOT NULL , ColorName VARCHAR(100) NOT NULL , ColorCode VARCHAR(100) NOT NULL , PRIMARY KEY(Trn_ThemeId, ColorId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE UNIQUE INDEX UTRN_THEMECOLOR1 ON Trn_ThemeColor (Trn_ThemeId ,ColorName ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX UTRN_THEMECOLOR1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE UNIQUE INDEX UTRN_THEMECOLOR1 ON Trn_ThemeColor (Trn_ThemeId ,ColorName ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateTrn_Theme( )
      {
         string cmdBuffer = "";
         /* Indices for table Trn_Theme */
         try
         {
            cmdBuffer=" CREATE TABLE Trn_Theme (Trn_ThemeId CHAR(36) NOT NULL , Trn_ThemeName VARCHAR(100) NOT NULL , Trn_ThemeFontFamily VARCHAR(40) NOT NULL , Trn_ThemeFontSize smallint NOT NULL , ThemeIsPredefined BOOLEAN NOT NULL , PRIMARY KEY(Trn_ThemeId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE Trn_Theme CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW Trn_Theme CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION Trn_Theme CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE Trn_Theme (Trn_ThemeId CHAR(36) NOT NULL , Trn_ThemeName VARCHAR(100) NOT NULL , Trn_ThemeFontFamily VARCHAR(40) NOT NULL , Trn_ThemeFontSize smallint NOT NULL , ThemeIsPredefined BOOLEAN NOT NULL , PRIMARY KEY(Trn_ThemeId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateTrn_AgendaCalendar( )
      {
         string cmdBuffer = "";
         /* Indices for table Trn_AgendaCalendar */
         try
         {
            cmdBuffer=" CREATE TABLE Trn_AgendaCalendar (AgendaCalendarId CHAR(36) NOT NULL , AgendaCalendarTitle VARCHAR(100) NOT NULL , AgendaCalendarStartDate timestamp without time zone NOT NULL , AgendaCalendarEndDate timestamp without time zone NOT NULL , AgendaCalendarAllDay BOOLEAN NOT NULL , LocationId CHAR(36) NOT NULL , OrganisationId CHAR(36) NOT NULL , AgendaCalendarType VARCHAR(40) NOT NULL , AgendaCalendarRecurring BOOLEAN NOT NULL , AgendaCalendarRecurringType VARCHAR(100) NOT NULL , AgendaCalendarAddRSVP BOOLEAN NOT NULL , PRIMARY KEY(AgendaCalendarId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE Trn_AgendaCalendar CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW Trn_AgendaCalendar CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION Trn_AgendaCalendar CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE Trn_AgendaCalendar (AgendaCalendarId CHAR(36) NOT NULL , AgendaCalendarTitle VARCHAR(100) NOT NULL , AgendaCalendarStartDate timestamp without time zone NOT NULL , AgendaCalendarEndDate timestamp without time zone NOT NULL , AgendaCalendarAllDay BOOLEAN NOT NULL , LocationId CHAR(36) NOT NULL , OrganisationId CHAR(36) NOT NULL , AgendaCalendarType VARCHAR(40) NOT NULL , AgendaCalendarRecurring BOOLEAN NOT NULL , AgendaCalendarRecurringType VARCHAR(100) NOT NULL , AgendaCalendarAddRSVP BOOLEAN NOT NULL , PRIMARY KEY(AgendaCalendarId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ITRN_AGENDACALENDAR1 ON Trn_AgendaCalendar (LocationId ,OrganisationId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ITRN_AGENDACALENDAR1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ITRN_AGENDACALENDAR1 ON Trn_AgendaCalendar (LocationId ,OrganisationId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateTrn_SupplierGenType( )
      {
         string cmdBuffer = "";
         /* Indices for table Trn_SupplierGenType */
         try
         {
            cmdBuffer=" CREATE TABLE Trn_SupplierGenType (SupplierGenTypeId CHAR(36) NOT NULL , SupplierGenTypeName VARCHAR(100) NOT NULL , PRIMARY KEY(SupplierGenTypeId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE Trn_SupplierGenType CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW Trn_SupplierGenType CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION Trn_SupplierGenType CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE Trn_SupplierGenType (SupplierGenTypeId CHAR(36) NOT NULL , SupplierGenTypeName VARCHAR(100) NOT NULL , PRIMARY KEY(SupplierGenTypeId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateTrn_SupplierAgbType( )
      {
         string cmdBuffer = "";
         /* Indices for table Trn_SupplierAgbType */
         try
         {
            cmdBuffer=" CREATE TABLE Trn_SupplierAgbType (SupplierAgbTypeId CHAR(36) NOT NULL , SupplierAgbTypeName VARCHAR(100) NOT NULL , PRIMARY KEY(SupplierAgbTypeId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE Trn_SupplierAgbType CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW Trn_SupplierAgbType CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION Trn_SupplierAgbType CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE Trn_SupplierAgbType (SupplierAgbTypeId CHAR(36) NOT NULL , SupplierAgbTypeName VARCHAR(100) NOT NULL , PRIMARY KEY(SupplierAgbTypeId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateUserCustomizations( )
      {
         string cmdBuffer = "";
         /* Indices for table UserCustomizations */
         try
         {
            cmdBuffer=" CREATE TABLE UserCustomizations (UserCustomizationsId CHAR(40) NOT NULL , UserCustomizationsKey VARCHAR(200) NOT NULL , UserCustomizationsValue TEXT NOT NULL , PRIMARY KEY(UserCustomizationsId, UserCustomizationsKey))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE UserCustomizations CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW UserCustomizations CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION UserCustomizations CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE UserCustomizations (UserCustomizationsId CHAR(40) NOT NULL , UserCustomizationsKey VARCHAR(200) NOT NULL , UserCustomizationsValue TEXT NOT NULL , PRIMARY KEY(UserCustomizationsId, UserCustomizationsKey))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateWWP_FormInstanceElement( )
      {
         string cmdBuffer = "";
         /* Indices for table WWP_FormInstanceElement */
         try
         {
            cmdBuffer=" CREATE TABLE WWP_FormInstanceElement (WWPFormInstanceId integer NOT NULL , WWPFormElementId smallint NOT NULL , WWPFormInstanceElementId smallint NOT NULL , WWPFormInstanceElemChar TEXT , WWPFormInstanceElemDate date , WWPFormInstanceElemDateTime timestamp without time zone , WWPFormInstanceElemNumeric NUMERIC(17,5) , WWPFormInstanceElemBlob BYTEA , WWPFormInstanceElemBlobFileNam VARCHAR(40) NOT NULL , WWPFormInstanceElemBlobFileTyp VARCHAR(40) NOT NULL , WWPFormInstanceElemBoolean BOOLEAN , PRIMARY KEY(WWPFormInstanceId, WWPFormElementId, WWPFormInstanceElementId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE WWP_FormInstanceElement CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW WWP_FormInstanceElement CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION WWP_FormInstanceElement CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE WWP_FormInstanceElement (WWPFormInstanceId integer NOT NULL , WWPFormElementId smallint NOT NULL , WWPFormInstanceElementId smallint NOT NULL , WWPFormInstanceElemChar TEXT , WWPFormInstanceElemDate date , WWPFormInstanceElemDateTime timestamp without time zone , WWPFormInstanceElemNumeric NUMERIC(17,5) , WWPFormInstanceElemBlob BYTEA , WWPFormInstanceElemBlobFileNam VARCHAR(40) NOT NULL , WWPFormInstanceElemBlobFileTyp VARCHAR(40) NOT NULL , WWPFormInstanceElemBoolean BOOLEAN , PRIMARY KEY(WWPFormInstanceId, WWPFormElementId, WWPFormInstanceElementId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateWWP_FormInstance( )
      {
         string cmdBuffer = "";
         /* Indices for table WWP_FormInstance */
         try
         {
            cmdBuffer=" CREATE SEQUENCE WWPFormInstanceId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE WWPFormInstanceId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE WWPFormInstanceId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE WWP_FormInstance (WWPFormInstanceId integer NOT NULL DEFAULT nextval('WWPFormInstanceId'), WWPFormInstanceDate timestamp without time zone NOT NULL , WWPFormId smallint NOT NULL , WWPFormVersionNumber smallint NOT NULL , WWPUserExtendedId CHAR(40) NOT NULL , WWPFormInstanceRecordKey TEXT , PRIMARY KEY(WWPFormInstanceId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE WWP_FormInstance CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW WWP_FormInstance CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION WWP_FormInstance CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE WWP_FormInstance (WWPFormInstanceId integer NOT NULL DEFAULT nextval('WWPFormInstanceId'), WWPFormInstanceDate timestamp without time zone NOT NULL , WWPFormId smallint NOT NULL , WWPFormVersionNumber smallint NOT NULL , WWPUserExtendedId CHAR(40) NOT NULL , WWPFormInstanceRecordKey TEXT , PRIMARY KEY(WWPFormInstanceId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX IWWP_FORMINSTANCE ON WWP_FormInstance (WWPUserExtendedId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX IWWP_FORMINSTANCE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX IWWP_FORMINSTANCE ON WWP_FormInstance (WWPUserExtendedId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX IWWPFORMINSTANCE1 ON WWP_FormInstance (WWPFormId ,WWPFormVersionNumber ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX IWWPFORMINSTANCE1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX IWWPFORMINSTANCE1 ON WWP_FormInstance (WWPFormId ,WWPFormVersionNumber ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateWWP_FormElement( )
      {
         string cmdBuffer = "";
         /* Indices for table WWP_FormElement */
         try
         {
            cmdBuffer=" CREATE TABLE WWP_FormElement (WWPFormId smallint NOT NULL , WWPFormVersionNumber smallint NOT NULL , WWPFormElementId smallint NOT NULL , WWPFormElementTitle TEXT NOT NULL , WWPFormElementType smallint NOT NULL , WWPFormElementOrderIndex smallint NOT NULL , WWPFormElementDataType smallint NOT NULL , WWPFormElementParentId smallint , WWPFormElementMetadata TEXT NOT NULL , WWPFormElementCaption smallint NOT NULL , WWPFormElementReferenceId VARCHAR(100) NOT NULL , WWPFormElementExcludeFromExpor BOOLEAN NOT NULL , PRIMARY KEY(WWPFormId, WWPFormVersionNumber, WWPFormElementId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE WWP_FormElement CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW WWP_FormElement CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION WWP_FormElement CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE WWP_FormElement (WWPFormId smallint NOT NULL , WWPFormVersionNumber smallint NOT NULL , WWPFormElementId smallint NOT NULL , WWPFormElementTitle TEXT NOT NULL , WWPFormElementType smallint NOT NULL , WWPFormElementOrderIndex smallint NOT NULL , WWPFormElementDataType smallint NOT NULL , WWPFormElementParentId smallint , WWPFormElementMetadata TEXT NOT NULL , WWPFormElementCaption smallint NOT NULL , WWPFormElementReferenceId VARCHAR(100) NOT NULL , WWPFormElementExcludeFromExpor BOOLEAN NOT NULL , PRIMARY KEY(WWPFormId, WWPFormVersionNumber, WWPFormElementId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX IWWPFORMELEMENT1 ON WWP_FormElement (WWPFormId ,WWPFormVersionNumber ,WWPFormElementParentId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX IWWPFORMELEMENT1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX IWWPFORMELEMENT1 ON WWP_FormElement (WWPFormId ,WWPFormVersionNumber ,WWPFormElementParentId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX UWWPFORMELEMENTORDER ON WWP_FormElement (WWPFormElementOrderIndex DESC) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX UWWPFORMELEMENTORDER "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX UWWPFORMELEMENTORDER ON WWP_FormElement (WWPFormElementOrderIndex DESC) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX UWWPFORMELEMENTREFERENCEID ON WWP_FormElement (WWPFormElementReferenceId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX UWWPFORMELEMENTREFERENCEID "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX UWWPFORMELEMENTREFERENCEID ON WWP_FormElement (WWPFormElementReferenceId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateWWP_Form( )
      {
         string cmdBuffer = "";
         /* Indices for table WWP_Form */
         try
         {
            cmdBuffer=" CREATE TABLE WWP_Form (WWPFormId smallint NOT NULL , WWPFormVersionNumber smallint NOT NULL , WWPFormReferenceName VARCHAR(100) NOT NULL , WWPFormTitle VARCHAR(100) NOT NULL , WWPFormDate timestamp without time zone NOT NULL , WWPFormIsWizard BOOLEAN NOT NULL , WWPFormResume smallint NOT NULL , WWPFormResumeMessage TEXT NOT NULL , WWPFormValidations TEXT NOT NULL , WWPFormInstantiated BOOLEAN NOT NULL , WWPFormType smallint NOT NULL , WWPFormSectionRefElements VARCHAR(400) NOT NULL , WWPFormIsForDynamicValidations BOOLEAN NOT NULL , PRIMARY KEY(WWPFormId, WWPFormVersionNumber))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE WWP_Form CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW WWP_Form CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION WWP_Form CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE WWP_Form (WWPFormId smallint NOT NULL , WWPFormVersionNumber smallint NOT NULL , WWPFormReferenceName VARCHAR(100) NOT NULL , WWPFormTitle VARCHAR(100) NOT NULL , WWPFormDate timestamp without time zone NOT NULL , WWPFormIsWizard BOOLEAN NOT NULL , WWPFormResume smallint NOT NULL , WWPFormResumeMessage TEXT NOT NULL , WWPFormValidations TEXT NOT NULL , WWPFormInstantiated BOOLEAN NOT NULL , WWPFormType smallint NOT NULL , WWPFormSectionRefElements VARCHAR(400) NOT NULL , WWPFormIsForDynamicValidations BOOLEAN NOT NULL , PRIMARY KEY(WWPFormId, WWPFormVersionNumber))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX UWWP_FORMVERSIONNUMBER ON WWP_Form (WWPFormVersionNumber DESC) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX UWWP_FORMVERSIONNUMBER "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX UWWP_FORMVERSIONNUMBER ON WWP_Form (WWPFormVersionNumber DESC) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX UWWP_FORMTITLE ON WWP_Form (WWPFormTitle ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX UWWP_FORMTITLE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX UWWP_FORMTITLE ON WWP_Form (WWPFormTitle ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX UWWP_FORMREFERENCEVERSION ON WWP_Form (WWPFormReferenceName ,WWPFormVersionNumber DESC) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX UWWP_FORMREFERENCEVERSION "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX UWWP_FORMREFERENCEVERSION ON WWP_Form (WWPFormReferenceName ,WWPFormVersionNumber DESC) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX UWWP_FORMIDVERSION ON WWP_Form (WWPFormId ,WWPFormVersionNumber DESC) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX UWWP_FORMIDVERSION "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX UWWP_FORMIDVERSION ON WWP_Form (WWPFormId ,WWPFormVersionNumber DESC) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateWWP_DiscussionMessageMention( )
      {
         string cmdBuffer = "";
         /* Indices for table WWP_DiscussionMessageMention */
         try
         {
            cmdBuffer=" CREATE TABLE WWP_DiscussionMessageMention (WWPDiscussionMessageId bigint NOT NULL , WWPDiscussionMentionUserId CHAR(40) NOT NULL , PRIMARY KEY(WWPDiscussionMessageId, WWPDiscussionMentionUserId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE WWP_DiscussionMessageMention CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW WWP_DiscussionMessageMention CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION WWP_DiscussionMessageMention CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE WWP_DiscussionMessageMention (WWPDiscussionMessageId bigint NOT NULL , WWPDiscussionMentionUserId CHAR(40) NOT NULL , PRIMARY KEY(WWPDiscussionMessageId, WWPDiscussionMentionUserId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX IWWP_DISCUSSIONMESSAGEMENTION1 ON WWP_DiscussionMessageMention (WWPDiscussionMentionUserId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX IWWP_DISCUSSIONMESSAGEMENTION1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX IWWP_DISCUSSIONMESSAGEMENTION1 ON WWP_DiscussionMessageMention (WWPDiscussionMentionUserId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateWWP_DiscussionMessage( )
      {
         string cmdBuffer = "";
         /* Indices for table WWP_DiscussionMessage */
         try
         {
            cmdBuffer=" CREATE SEQUENCE WWPDiscussionMessageId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE WWPDiscussionMessageId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE WWPDiscussionMessageId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE WWP_DiscussionMessage (WWPDiscussionMessageId bigint NOT NULL DEFAULT nextval('WWPDiscussionMessageId'), WWPDiscussionMessageDate timestamp without time zone NOT NULL , WWPDiscussionMessageThreadId bigint , WWPDiscussionMessageMessage VARCHAR(400) NOT NULL , WWPUserExtendedId CHAR(40) NOT NULL , WWPEntityId bigint NOT NULL , WWPDiscussionMessageEntityReco VARCHAR(100) NOT NULL , PRIMARY KEY(WWPDiscussionMessageId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE WWP_DiscussionMessage CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW WWP_DiscussionMessage CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION WWP_DiscussionMessage CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE WWP_DiscussionMessage (WWPDiscussionMessageId bigint NOT NULL DEFAULT nextval('WWPDiscussionMessageId'), WWPDiscussionMessageDate timestamp without time zone NOT NULL , WWPDiscussionMessageThreadId bigint , WWPDiscussionMessageMessage VARCHAR(400) NOT NULL , WWPUserExtendedId CHAR(40) NOT NULL , WWPEntityId bigint NOT NULL , WWPDiscussionMessageEntityReco VARCHAR(100) NOT NULL , PRIMARY KEY(WWPDiscussionMessageId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX IWWP_DISCUSSIONMESSAGE1 ON WWP_DiscussionMessage (WWPDiscussionMessageThreadId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX IWWP_DISCUSSIONMESSAGE1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX IWWP_DISCUSSIONMESSAGE1 ON WWP_DiscussionMessage (WWPDiscussionMessageThreadId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX IWWP_DISCUSSIONMESSAGE2 ON WWP_DiscussionMessage (WWPEntityId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX IWWP_DISCUSSIONMESSAGE2 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX IWWP_DISCUSSIONMESSAGE2 ON WWP_DiscussionMessage (WWPEntityId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX IWWP_DISCUSSIONMESSAGE3 ON WWP_DiscussionMessage (WWPUserExtendedId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX IWWP_DISCUSSIONMESSAGE3 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX IWWP_DISCUSSIONMESSAGE3 ON WWP_DiscussionMessage (WWPUserExtendedId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateWWP_MailAttachments( )
      {
         string cmdBuffer = "";
         /* Indices for table WWP_MailAttachments */
         try
         {
            cmdBuffer=" CREATE TABLE WWP_MailAttachments (WWPMailId bigint NOT NULL , WWPMailAttachmentName VARCHAR(40) NOT NULL , WWPMailAttachmentFile TEXT NOT NULL , PRIMARY KEY(WWPMailId, WWPMailAttachmentName))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE WWP_MailAttachments CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW WWP_MailAttachments CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION WWP_MailAttachments CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE WWP_MailAttachments (WWPMailId bigint NOT NULL , WWPMailAttachmentName VARCHAR(40) NOT NULL , WWPMailAttachmentFile TEXT NOT NULL , PRIMARY KEY(WWPMailId, WWPMailAttachmentName))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateWWP_Mail( )
      {
         string cmdBuffer = "";
         /* Indices for table WWP_Mail */
         try
         {
            cmdBuffer=" CREATE SEQUENCE WWPMailId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE WWPMailId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE WWPMailId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE WWP_Mail (WWPMailId bigint NOT NULL DEFAULT nextval('WWPMailId'), WWPMailSubject VARCHAR(80) NOT NULL , WWPMailBody TEXT NOT NULL , WWPMailTo TEXT , WWPMailCC TEXT , WWPMailBCC TEXT , WWPMailSenderAddress TEXT NOT NULL , WWPMailSenderName TEXT NOT NULL , WWPMailStatus smallint NOT NULL , WWPMailCreated timestamp without time zone NOT NULL , WWPMailScheduled timestamp without time zone NOT NULL , WWPMailProcessed timestamp without time zone , WWPMailDetail TEXT , WWPNotificationId bigint , PRIMARY KEY(WWPMailId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE WWP_Mail CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW WWP_Mail CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION WWP_Mail CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE WWP_Mail (WWPMailId bigint NOT NULL DEFAULT nextval('WWPMailId'), WWPMailSubject VARCHAR(80) NOT NULL , WWPMailBody TEXT NOT NULL , WWPMailTo TEXT , WWPMailCC TEXT , WWPMailBCC TEXT , WWPMailSenderAddress TEXT NOT NULL , WWPMailSenderName TEXT NOT NULL , WWPMailStatus smallint NOT NULL , WWPMailCreated timestamp without time zone NOT NULL , WWPMailScheduled timestamp without time zone NOT NULL , WWPMailProcessed timestamp without time zone , WWPMailDetail TEXT , WWPNotificationId bigint , PRIMARY KEY(WWPMailId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX IWWP_MAIL1 ON WWP_Mail (WWPNotificationId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX IWWP_MAIL1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX IWWP_MAIL1 ON WWP_Mail (WWPNotificationId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateWWP_MailTemplate( )
      {
         string cmdBuffer = "";
         /* Indices for table WWP_MailTemplate */
         try
         {
            cmdBuffer=" CREATE TABLE WWP_MailTemplate (WWPMailTemplateName VARCHAR(40) NOT NULL , WWPMailTemplateDescription VARCHAR(100) NOT NULL , WWPMailTemplateSubject VARCHAR(80) NOT NULL , WWPMailTemplateBody TEXT NOT NULL , WWPMailTemplateSenderAddress TEXT NOT NULL , WWPMailTemplateSenderName TEXT NOT NULL , PRIMARY KEY(WWPMailTemplateName))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE WWP_MailTemplate CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW WWP_MailTemplate CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION WWP_MailTemplate CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE WWP_MailTemplate (WWPMailTemplateName VARCHAR(40) NOT NULL , WWPMailTemplateDescription VARCHAR(100) NOT NULL , WWPMailTemplateSubject VARCHAR(80) NOT NULL , WWPMailTemplateBody TEXT NOT NULL , WWPMailTemplateSenderAddress TEXT NOT NULL , WWPMailTemplateSenderName TEXT NOT NULL , PRIMARY KEY(WWPMailTemplateName))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateWWP_Notification( )
      {
         string cmdBuffer = "";
         /* Indices for table WWP_Notification */
         try
         {
            cmdBuffer=" CREATE SEQUENCE WWPNotificationId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE WWPNotificationId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE WWPNotificationId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE WWP_Notification (WWPNotificationId bigint NOT NULL DEFAULT nextval('WWPNotificationId'), WWPNotificationDefinitionId bigint NOT NULL , WWPNotificationCreated timestamp without time zone NOT NULL , WWPNotificationIcon VARCHAR(100) NOT NULL , WWPNotificationTitle VARCHAR(200) NOT NULL , WWPNotificationShortDescriptio VARCHAR(200) NOT NULL , WWPNotificationLink VARCHAR(1000) NOT NULL , WWPNotificationIsRead BOOLEAN NOT NULL , WWPUserExtendedId CHAR(40) , WWPNotificationMetadata TEXT , PRIMARY KEY(WWPNotificationId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE WWP_Notification CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW WWP_Notification CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION WWP_Notification CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE WWP_Notification (WWPNotificationId bigint NOT NULL DEFAULT nextval('WWPNotificationId'), WWPNotificationDefinitionId bigint NOT NULL , WWPNotificationCreated timestamp without time zone NOT NULL , WWPNotificationIcon VARCHAR(100) NOT NULL , WWPNotificationTitle VARCHAR(200) NOT NULL , WWPNotificationShortDescriptio VARCHAR(200) NOT NULL , WWPNotificationLink VARCHAR(1000) NOT NULL , WWPNotificationIsRead BOOLEAN NOT NULL , WWPUserExtendedId CHAR(40) , WWPNotificationMetadata TEXT , PRIMARY KEY(WWPNotificationId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX IWWP_NOTIFICATION1 ON WWP_Notification (WWPUserExtendedId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX IWWP_NOTIFICATION1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX IWWP_NOTIFICATION1 ON WWP_Notification (WWPUserExtendedId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX IWWP_NOTIFICATION2 ON WWP_Notification (WWPNotificationDefinitionId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX IWWP_NOTIFICATION2 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX IWWP_NOTIFICATION2 ON WWP_Notification (WWPNotificationDefinitionId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX WWP_NOTIFICATIONCREATEDDATE ON WWP_Notification (WWPNotificationCreated DESC) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX WWP_NOTIFICATIONCREATEDDATE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX WWP_NOTIFICATIONCREATEDDATE ON WWP_Notification (WWPNotificationCreated DESC) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateWWP_NotificationDefinition( )
      {
         string cmdBuffer = "";
         /* Indices for table WWP_NotificationDefinition */
         try
         {
            cmdBuffer=" CREATE SEQUENCE WWPNotificationDefinitionId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE WWPNotificationDefinitionId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE WWPNotificationDefinitionId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE WWP_NotificationDefinition (WWPNotificationDefinitionId bigint NOT NULL DEFAULT nextval('WWPNotificationDefinitionId'), WWPNotificationDefinitionName VARCHAR(100) NOT NULL , WWPNotificationDefinitionAppli smallint NOT NULL , WWPNotificationDefinitionAllow BOOLEAN NOT NULL , WWPNotificationDefinitionDescr VARCHAR(200) NOT NULL , WWPNotificationDefinitionIcon VARCHAR(40) NOT NULL , WWPNotificationDefinitionTitle VARCHAR(200) NOT NULL , WWPNotificationDefinitionShort VARCHAR(200) NOT NULL , WWPNotificationDefinitionLongD VARCHAR(1000) NOT NULL , WWPNotificationDefinitionLink VARCHAR(1000) NOT NULL , WWPEntityId bigint NOT NULL , WWPNotificationDefinitionSecFu VARCHAR(200) NOT NULL , PRIMARY KEY(WWPNotificationDefinitionId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE WWP_NotificationDefinition CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW WWP_NotificationDefinition CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION WWP_NotificationDefinition CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE WWP_NotificationDefinition (WWPNotificationDefinitionId bigint NOT NULL DEFAULT nextval('WWPNotificationDefinitionId'), WWPNotificationDefinitionName VARCHAR(100) NOT NULL , WWPNotificationDefinitionAppli smallint NOT NULL , WWPNotificationDefinitionAllow BOOLEAN NOT NULL , WWPNotificationDefinitionDescr VARCHAR(200) NOT NULL , WWPNotificationDefinitionIcon VARCHAR(40) NOT NULL , WWPNotificationDefinitionTitle VARCHAR(200) NOT NULL , WWPNotificationDefinitionShort VARCHAR(200) NOT NULL , WWPNotificationDefinitionLongD VARCHAR(1000) NOT NULL , WWPNotificationDefinitionLink VARCHAR(1000) NOT NULL , WWPEntityId bigint NOT NULL , WWPNotificationDefinitionSecFu VARCHAR(200) NOT NULL , PRIMARY KEY(WWPNotificationDefinitionId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX IWWP_NOTIFICATIONDEFINITION1 ON WWP_NotificationDefinition (WWPEntityId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX IWWP_NOTIFICATIONDEFINITION1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX IWWP_NOTIFICATIONDEFINITION1 ON WWP_NotificationDefinition (WWPEntityId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateWWP_WebClient( )
      {
         string cmdBuffer = "";
         /* Indices for table WWP_WebClient */
         try
         {
            cmdBuffer=" CREATE TABLE WWP_WebClient (WWPWebClientId CHAR(100) NOT NULL , WWPWebClientBrowserId smallint NOT NULL , WWPWebClientBrowserVersion TEXT NOT NULL , WWPWebClientFirstRegistered timestamp without time zone NOT NULL , WWPWebClientLastRegistered timestamp without time zone NOT NULL , WWPUserExtendedId CHAR(40) , PRIMARY KEY(WWPWebClientId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE WWP_WebClient CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW WWP_WebClient CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION WWP_WebClient CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE WWP_WebClient (WWPWebClientId CHAR(100) NOT NULL , WWPWebClientBrowserId smallint NOT NULL , WWPWebClientBrowserVersion TEXT NOT NULL , WWPWebClientFirstRegistered timestamp without time zone NOT NULL , WWPWebClientLastRegistered timestamp without time zone NOT NULL , WWPUserExtendedId CHAR(40) , PRIMARY KEY(WWPWebClientId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX IWWP_WEBCLIENT1 ON WWP_WebClient (WWPUserExtendedId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX IWWP_WEBCLIENT1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX IWWP_WEBCLIENT1 ON WWP_WebClient (WWPUserExtendedId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateWWP_WebNotification( )
      {
         string cmdBuffer = "";
         /* Indices for table WWP_WebNotification */
         try
         {
            cmdBuffer=" CREATE SEQUENCE WWPWebNotificationId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE WWPWebNotificationId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE WWPWebNotificationId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE WWP_WebNotification (WWPWebNotificationId bigint NOT NULL DEFAULT nextval('WWPWebNotificationId'), WWPWebNotificationTitle VARCHAR(40) NOT NULL , WWPNotificationId bigint , WWPWebNotificationText VARCHAR(120) NOT NULL , WWPWebNotificationIcon VARCHAR(255) NOT NULL , WWPWebNotificationClientId TEXT NOT NULL , WWPWebNotificationStatus smallint NOT NULL , WWPWebNotificationCreated timestamp without time zone NOT NULL , WWPWebNotificationScheduled timestamp without time zone NOT NULL , WWPWebNotificationProcessed timestamp without time zone NOT NULL , WWPWebNotificationRead timestamp without time zone , WWPWebNotificationDetail TEXT , WWPWebNotificationReceived BOOLEAN , PRIMARY KEY(WWPWebNotificationId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE WWP_WebNotification CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW WWP_WebNotification CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION WWP_WebNotification CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE WWP_WebNotification (WWPWebNotificationId bigint NOT NULL DEFAULT nextval('WWPWebNotificationId'), WWPWebNotificationTitle VARCHAR(40) NOT NULL , WWPNotificationId bigint , WWPWebNotificationText VARCHAR(120) NOT NULL , WWPWebNotificationIcon VARCHAR(255) NOT NULL , WWPWebNotificationClientId TEXT NOT NULL , WWPWebNotificationStatus smallint NOT NULL , WWPWebNotificationCreated timestamp without time zone NOT NULL , WWPWebNotificationScheduled timestamp without time zone NOT NULL , WWPWebNotificationProcessed timestamp without time zone NOT NULL , WWPWebNotificationRead timestamp without time zone , WWPWebNotificationDetail TEXT , WWPWebNotificationReceived BOOLEAN , PRIMARY KEY(WWPWebNotificationId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX IWWP_WEBNOTIFICATION1 ON WWP_WebNotification (WWPNotificationId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX IWWP_WEBNOTIFICATION1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX IWWP_WEBNOTIFICATION1 ON WWP_WebNotification (WWPNotificationId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateWWP_SMS( )
      {
         string cmdBuffer = "";
         /* Indices for table WWP_SMS */
         try
         {
            cmdBuffer=" CREATE SEQUENCE WWPSMSId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE WWPSMSId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE WWPSMSId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE WWP_SMS (WWPSMSId bigint NOT NULL DEFAULT nextval('WWPSMSId'), WWPSMSMessage TEXT NOT NULL , WWPSMSSenderNumber TEXT NOT NULL , WWPSMSRecipientNumbers TEXT NOT NULL , WWPSMSStatus smallint NOT NULL , WWPSMSCreated timestamp without time zone NOT NULL , WWPSMSScheduled timestamp without time zone NOT NULL , WWPSMSProcessed timestamp without time zone , WWPSMSDetail TEXT , WWPNotificationId bigint , PRIMARY KEY(WWPSMSId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE WWP_SMS CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW WWP_SMS CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION WWP_SMS CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE WWP_SMS (WWPSMSId bigint NOT NULL DEFAULT nextval('WWPSMSId'), WWPSMSMessage TEXT NOT NULL , WWPSMSSenderNumber TEXT NOT NULL , WWPSMSRecipientNumbers TEXT NOT NULL , WWPSMSStatus smallint NOT NULL , WWPSMSCreated timestamp without time zone NOT NULL , WWPSMSScheduled timestamp without time zone NOT NULL , WWPSMSProcessed timestamp without time zone , WWPSMSDetail TEXT , WWPNotificationId bigint , PRIMARY KEY(WWPSMSId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX IWWP_SMS1 ON WWP_SMS (WWPNotificationId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX IWWP_SMS1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX IWWP_SMS1 ON WWP_SMS (WWPNotificationId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateWWP_Subscription( )
      {
         string cmdBuffer = "";
         /* Indices for table WWP_Subscription */
         try
         {
            cmdBuffer=" CREATE SEQUENCE WWPSubscriptionId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE WWPSubscriptionId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE WWPSubscriptionId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE WWP_Subscription (WWPSubscriptionId bigint NOT NULL DEFAULT nextval('WWPSubscriptionId'), WWPNotificationDefinitionId bigint NOT NULL , WWPUserExtendedId CHAR(40) , WWPSubscriptionEntityRecordId VARCHAR(2000) NOT NULL , WWPSubscriptionEntityRecordDes VARCHAR(200) NOT NULL , WWPSubscriptionRoleId CHAR(40) , WWPSubscriptionSubscribed BOOLEAN NOT NULL , PRIMARY KEY(WWPSubscriptionId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE WWP_Subscription CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW WWP_Subscription CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION WWP_Subscription CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE WWP_Subscription (WWPSubscriptionId bigint NOT NULL DEFAULT nextval('WWPSubscriptionId'), WWPNotificationDefinitionId bigint NOT NULL , WWPUserExtendedId CHAR(40) , WWPSubscriptionEntityRecordId VARCHAR(2000) NOT NULL , WWPSubscriptionEntityRecordDes VARCHAR(200) NOT NULL , WWPSubscriptionRoleId CHAR(40) , WWPSubscriptionSubscribed BOOLEAN NOT NULL , PRIMARY KEY(WWPSubscriptionId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX IWWP_SUBSCRIPTION1 ON WWP_Subscription (WWPUserExtendedId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX IWWP_SUBSCRIPTION1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX IWWP_SUBSCRIPTION1 ON WWP_Subscription (WWPUserExtendedId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX IWWP_SUBSCRIPTION2 ON WWP_Subscription (WWPNotificationDefinitionId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX IWWP_SUBSCRIPTION2 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX IWWP_SUBSCRIPTION2 ON WWP_Subscription (WWPNotificationDefinitionId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateWWP_Entity( )
      {
         string cmdBuffer = "";
         /* Indices for table WWP_Entity */
         try
         {
            cmdBuffer=" CREATE SEQUENCE WWPEntityId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE WWPEntityId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE WWPEntityId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE WWP_Entity (WWPEntityId bigint NOT NULL DEFAULT nextval('WWPEntityId'), WWPEntityName VARCHAR(100) NOT NULL , PRIMARY KEY(WWPEntityId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE WWP_Entity CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW WWP_Entity CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION WWP_Entity CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE WWP_Entity (WWPEntityId bigint NOT NULL DEFAULT nextval('WWPEntityId'), WWPEntityName VARCHAR(100) NOT NULL , PRIMARY KEY(WWPEntityId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateWWP_Parameter( )
      {
         string cmdBuffer = "";
         /* Indices for table WWP_Parameter */
         try
         {
            cmdBuffer=" CREATE TABLE WWP_Parameter (WWPParameterKey VARCHAR(300) NOT NULL , WWPParameterCategory VARCHAR(200) NOT NULL , WWPParameterDescription VARCHAR(200) NOT NULL , WWPParameterValue TEXT NOT NULL , WWPParameterDisableDelete BOOLEAN NOT NULL , PRIMARY KEY(WWPParameterKey))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE WWP_Parameter CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW WWP_Parameter CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION WWP_Parameter CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE WWP_Parameter (WWPParameterKey VARCHAR(300) NOT NULL , WWPParameterCategory VARCHAR(200) NOT NULL , WWPParameterDescription VARCHAR(200) NOT NULL , WWPParameterValue TEXT NOT NULL , WWPParameterDisableDelete BOOLEAN NOT NULL , PRIMARY KEY(WWPParameterKey))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateWWP_UserExtended( )
      {
         string cmdBuffer = "";
         /* Indices for table WWP_UserExtended */
         try
         {
            cmdBuffer=" CREATE TABLE WWP_UserExtended (WWPUserExtendedId CHAR(40) NOT NULL , WWPUserExtendedPhoto BYTEA NOT NULL , WWPUserExtendedPhoto_GXI VARCHAR(2048) , WWPUserExtendedName VARCHAR(100) NOT NULL , WWPUserExtendedFullName VARCHAR(100) NOT NULL , WWPUserExtendedPhone CHAR(20) NOT NULL , WWPUserExtendedEmail VARCHAR(100) NOT NULL , WWPUserExtendedEmaiNotif BOOLEAN NOT NULL , WWPUserExtendedSMSNotif BOOLEAN NOT NULL , WWPUserExtendedMobileNotif BOOLEAN NOT NULL , WWPUserExtendedDesktopNotif BOOLEAN NOT NULL , WWPUserExtendedDeleted BOOLEAN NOT NULL , WWPUserExtendedDeletedIn timestamp without time zone , PRIMARY KEY(WWPUserExtendedId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE WWP_UserExtended CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW WWP_UserExtended CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION WWP_UserExtended CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE WWP_UserExtended (WWPUserExtendedId CHAR(40) NOT NULL , WWPUserExtendedPhoto BYTEA NOT NULL , WWPUserExtendedPhoto_GXI VARCHAR(2048) , WWPUserExtendedName VARCHAR(100) NOT NULL , WWPUserExtendedFullName VARCHAR(100) NOT NULL , WWPUserExtendedPhone CHAR(20) NOT NULL , WWPUserExtendedEmail VARCHAR(100) NOT NULL , WWPUserExtendedEmaiNotif BOOLEAN NOT NULL , WWPUserExtendedSMSNotif BOOLEAN NOT NULL , WWPUserExtendedMobileNotif BOOLEAN NOT NULL , WWPUserExtendedDesktopNotif BOOLEAN NOT NULL , WWPUserExtendedDeleted BOOLEAN NOT NULL , WWPUserExtendedDeletedIn timestamp without time zone , PRIMARY KEY(WWPUserExtendedId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateTrn_MedicalIndication( )
      {
         string cmdBuffer = "";
         /* Indices for table Trn_MedicalIndication */
         try
         {
            cmdBuffer=" CREATE TABLE Trn_MedicalIndication (MedicalIndicationId CHAR(36) NOT NULL , MedicalIndicationName VARCHAR(100) NOT NULL , PRIMARY KEY(MedicalIndicationId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE Trn_MedicalIndication CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW Trn_MedicalIndication CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION Trn_MedicalIndication CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE Trn_MedicalIndication (MedicalIndicationId CHAR(36) NOT NULL , MedicalIndicationName VARCHAR(100) NOT NULL , PRIMARY KEY(MedicalIndicationId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateTrn_ResidentType( )
      {
         string cmdBuffer = "";
         /* Indices for table Trn_ResidentType */
         try
         {
            cmdBuffer=" CREATE TABLE Trn_ResidentType (ResidentTypeId CHAR(36) NOT NULL , ResidentTypeName VARCHAR(100) NOT NULL , PRIMARY KEY(ResidentTypeId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE Trn_ResidentType CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW Trn_ResidentType CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION Trn_ResidentType CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE Trn_ResidentType (ResidentTypeId CHAR(36) NOT NULL , ResidentTypeName VARCHAR(100) NOT NULL , PRIMARY KEY(ResidentTypeId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateTrn_NetworkCompany( )
      {
         string cmdBuffer = "";
         /* Indices for table Trn_NetworkCompany */
         try
         {
            cmdBuffer=" CREATE TABLE Trn_NetworkCompany (NetworkCompanyId CHAR(36) NOT NULL , NetworkCompanyKvkNumber VARCHAR(8) NOT NULL , NetworkCompanyName VARCHAR(100) NOT NULL , NetworkCompanyEmail VARCHAR(100) NOT NULL , NetworkCompanyPhone CHAR(20) NOT NULL , NetworkCompanyCountry VARCHAR(100) NOT NULL , NetworkCompanyCity VARCHAR(100) NOT NULL , NetworkCompanyZipCode VARCHAR(100) NOT NULL , NetworkCompanyAddressLine1 VARCHAR(100) NOT NULL , NetworkCompanyAddressLine2 VARCHAR(100) NOT NULL , NetworkCompanyPhoneCode VARCHAR(40) NOT NULL , NetworkCompanyPhoneNumber VARCHAR(9) NOT NULL , NetworkCompanyContactName VARCHAR(100) NOT NULL , PRIMARY KEY(NetworkCompanyId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE Trn_NetworkCompany CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW Trn_NetworkCompany CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION Trn_NetworkCompany CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE Trn_NetworkCompany (NetworkCompanyId CHAR(36) NOT NULL , NetworkCompanyKvkNumber VARCHAR(8) NOT NULL , NetworkCompanyName VARCHAR(100) NOT NULL , NetworkCompanyEmail VARCHAR(100) NOT NULL , NetworkCompanyPhone CHAR(20) NOT NULL , NetworkCompanyCountry VARCHAR(100) NOT NULL , NetworkCompanyCity VARCHAR(100) NOT NULL , NetworkCompanyZipCode VARCHAR(100) NOT NULL , NetworkCompanyAddressLine1 VARCHAR(100) NOT NULL , NetworkCompanyAddressLine2 VARCHAR(100) NOT NULL , NetworkCompanyPhoneCode VARCHAR(40) NOT NULL , NetworkCompanyPhoneNumber VARCHAR(9) NOT NULL , NetworkCompanyContactName VARCHAR(100) NOT NULL , PRIMARY KEY(NetworkCompanyId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateTrn_NetworkIndividual( )
      {
         string cmdBuffer = "";
         /* Indices for table Trn_NetworkIndividual */
         try
         {
            cmdBuffer=" CREATE TABLE Trn_NetworkIndividual (NetworkIndividualId CHAR(36) NOT NULL , NetworkIndividualBsnNumber VARCHAR(9) NOT NULL , NetworkIndividualGivenName VARCHAR(100) NOT NULL , NetworkIndividualLastName VARCHAR(100) NOT NULL , NetworkIndividualEmail VARCHAR(100) NOT NULL , NetworkIndividualPhone CHAR(20) NOT NULL , NetworkIndividualGender VARCHAR(40) NOT NULL , NetworkIndividualCountry VARCHAR(100) NOT NULL , NetworkIndividualCity VARCHAR(100) NOT NULL , NetworkIndividualZipCode VARCHAR(100) NOT NULL , NetworkIndividualAddressLine1 VARCHAR(100) NOT NULL , NetworkIndividualAddressLine2 VARCHAR(100) NOT NULL , NetworkIndividualPhoneCode VARCHAR(40) NOT NULL , NetworkIndividualPhoneNumber VARCHAR(9) NOT NULL , NetworkIndividualHomePhone CHAR(20) NOT NULL , NetworkIndividualHomePhoneCode VARCHAR(40) NOT NULL , NetworkIndividualHomePhoneNumb VARCHAR(9) NOT NULL , NetworkIndividualRelationship VARCHAR(400) NOT NULL , PRIMARY KEY(NetworkIndividualId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE Trn_NetworkIndividual CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW Trn_NetworkIndividual CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION Trn_NetworkIndividual CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE Trn_NetworkIndividual (NetworkIndividualId CHAR(36) NOT NULL , NetworkIndividualBsnNumber VARCHAR(9) NOT NULL , NetworkIndividualGivenName VARCHAR(100) NOT NULL , NetworkIndividualLastName VARCHAR(100) NOT NULL , NetworkIndividualEmail VARCHAR(100) NOT NULL , NetworkIndividualPhone CHAR(20) NOT NULL , NetworkIndividualGender VARCHAR(40) NOT NULL , NetworkIndividualCountry VARCHAR(100) NOT NULL , NetworkIndividualCity VARCHAR(100) NOT NULL , NetworkIndividualZipCode VARCHAR(100) NOT NULL , NetworkIndividualAddressLine1 VARCHAR(100) NOT NULL , NetworkIndividualAddressLine2 VARCHAR(100) NOT NULL , NetworkIndividualPhoneCode VARCHAR(40) NOT NULL , NetworkIndividualPhoneNumber VARCHAR(9) NOT NULL , NetworkIndividualHomePhone CHAR(20) NOT NULL , NetworkIndividualHomePhoneCode VARCHAR(40) NOT NULL , NetworkIndividualHomePhoneNumb VARCHAR(9) NOT NULL , NetworkIndividualRelationship VARCHAR(400) NOT NULL , PRIMARY KEY(NetworkIndividualId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateTrn_SupplierAGB( )
      {
         string cmdBuffer = "";
         /* Indices for table Trn_SupplierAGB */
         try
         {
            cmdBuffer=" CREATE TABLE Trn_SupplierAGB (SupplierAgbId CHAR(36) NOT NULL , SupplierAgbNumber VARCHAR(8) NOT NULL , SupplierAgbName VARCHAR(100) NOT NULL , SupplierAgbKvkNumber VARCHAR(8) NOT NULL , SupplierAgbContactName VARCHAR(100) NOT NULL , SupplierAgbPhone CHAR(20) NOT NULL , SupplierAgbEmail VARCHAR(100) NOT NULL , SupplierAgbTypeId CHAR(36) NOT NULL , SupplierAgbAddressZipCode VARCHAR(100) NOT NULL , SupplierAgbAddressCity VARCHAR(100) NOT NULL , SupplierAGBAddressCountry VARCHAR(100) NOT NULL , SupplierAgbAddressLine1 VARCHAR(100) NOT NULL , SupplierAgbAddressLine2 VARCHAR(100) NOT NULL , SupplierAgbPhoneCode VARCHAR(40) NOT NULL , SupplierAgbPhoneNumber VARCHAR(9) NOT NULL , SupplierAgbWebsite VARCHAR(50) NOT NULL , PRIMARY KEY(SupplierAgbId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE Trn_SupplierAGB CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW Trn_SupplierAGB CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION Trn_SupplierAGB CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE Trn_SupplierAGB (SupplierAgbId CHAR(36) NOT NULL , SupplierAgbNumber VARCHAR(8) NOT NULL , SupplierAgbName VARCHAR(100) NOT NULL , SupplierAgbKvkNumber VARCHAR(8) NOT NULL , SupplierAgbContactName VARCHAR(100) NOT NULL , SupplierAgbPhone CHAR(20) NOT NULL , SupplierAgbEmail VARCHAR(100) NOT NULL , SupplierAgbTypeId CHAR(36) NOT NULL , SupplierAgbAddressZipCode VARCHAR(100) NOT NULL , SupplierAgbAddressCity VARCHAR(100) NOT NULL , SupplierAGBAddressCountry VARCHAR(100) NOT NULL , SupplierAgbAddressLine1 VARCHAR(100) NOT NULL , SupplierAgbAddressLine2 VARCHAR(100) NOT NULL , SupplierAgbPhoneCode VARCHAR(40) NOT NULL , SupplierAgbPhoneNumber VARCHAR(9) NOT NULL , SupplierAgbWebsite VARCHAR(50) NOT NULL , PRIMARY KEY(SupplierAgbId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ITRN_SUPPLIERAGB1 ON Trn_SupplierAGB (SupplierAgbTypeId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ITRN_SUPPLIERAGB1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ITRN_SUPPLIERAGB1 ON Trn_SupplierAGB (SupplierAgbTypeId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX UTRN_SUPPLIERAGB ON Trn_SupplierAGB (SupplierAgbName ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX UTRN_SUPPLIERAGB "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX UTRN_SUPPLIERAGB ON Trn_SupplierAGB (SupplierAgbName ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateTrn_SupplierGen( )
      {
         string cmdBuffer = "";
         /* Indices for table Trn_SupplierGen */
         try
         {
            cmdBuffer=" CREATE TABLE Trn_SupplierGen (SupplierGenId CHAR(36) NOT NULL , SupplierGenKvkNumber VARCHAR(8) NOT NULL , SupplierGenCompanyName VARCHAR(100) NOT NULL , SupplierGenContactName VARCHAR(100) NOT NULL , SupplierGenContactPhone CHAR(20) NOT NULL , SupplierGenTypeId CHAR(36) NOT NULL , SupplierGenAddressZipCode VARCHAR(100) NOT NULL , SupplierGenAddressCity VARCHAR(100) NOT NULL , SupplierGenAddressCountry VARCHAR(100) NOT NULL , SupplierGenAddressLine1 VARCHAR(100) NOT NULL , SupplierGenAddressLine2 VARCHAR(100) NOT NULL , SupplierGenPhoneCode VARCHAR(40) NOT NULL , SupplierGenPhoneNumber VARCHAR(9) NOT NULL , SupplierGenWebsite VARCHAR(150) NOT NULL , SupplierGenEmail VARCHAR(100) NOT NULL , SupplierGenLandlineCode VARCHAR(40) NOT NULL , SupplierGenLandlineSubNumber VARCHAR(9) NOT NULL , SupplierGenLandlineNumber VARCHAR(40) NOT NULL , SupplierGenDescription TEXT NOT NULL , SG_OrganisationSupplierId CHAR(36) , SG_LocationSupplierOrganisatio CHAR(36) , SG_LocationSupplierLocationId CHAR(36) , PRIMARY KEY(SupplierGenId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE Trn_SupplierGen CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW Trn_SupplierGen CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION Trn_SupplierGen CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE Trn_SupplierGen (SupplierGenId CHAR(36) NOT NULL , SupplierGenKvkNumber VARCHAR(8) NOT NULL , SupplierGenCompanyName VARCHAR(100) NOT NULL , SupplierGenContactName VARCHAR(100) NOT NULL , SupplierGenContactPhone CHAR(20) NOT NULL , SupplierGenTypeId CHAR(36) NOT NULL , SupplierGenAddressZipCode VARCHAR(100) NOT NULL , SupplierGenAddressCity VARCHAR(100) NOT NULL , SupplierGenAddressCountry VARCHAR(100) NOT NULL , SupplierGenAddressLine1 VARCHAR(100) NOT NULL , SupplierGenAddressLine2 VARCHAR(100) NOT NULL , SupplierGenPhoneCode VARCHAR(40) NOT NULL , SupplierGenPhoneNumber VARCHAR(9) NOT NULL , SupplierGenWebsite VARCHAR(150) NOT NULL , SupplierGenEmail VARCHAR(100) NOT NULL , SupplierGenLandlineCode VARCHAR(40) NOT NULL , SupplierGenLandlineSubNumber VARCHAR(9) NOT NULL , SupplierGenLandlineNumber VARCHAR(40) NOT NULL , SupplierGenDescription TEXT NOT NULL , SG_OrganisationSupplierId CHAR(36) , SG_LocationSupplierOrganisatio CHAR(36) , SG_LocationSupplierLocationId CHAR(36) , PRIMARY KEY(SupplierGenId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ITRN_SUPPLIERGEN1 ON Trn_SupplierGen (SupplierGenTypeId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ITRN_SUPPLIERGEN1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ITRN_SUPPLIERGEN1 ON Trn_SupplierGen (SupplierGenTypeId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX UTRN_SUPPLIERGEN ON Trn_SupplierGen (SupplierGenCompanyName ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX UTRN_SUPPLIERGEN "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX UTRN_SUPPLIERGEN ON Trn_SupplierGen (SupplierGenCompanyName ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ITRN_SUPPLIERGEN2 ON Trn_SupplierGen (SG_OrganisationSupplierId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ITRN_SUPPLIERGEN2 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ITRN_SUPPLIERGEN2 ON Trn_SupplierGen (SG_OrganisationSupplierId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ITRN_SUPPLIERGEN3 ON Trn_SupplierGen (SG_LocationSupplierLocationId ,SG_LocationSupplierOrganisatio ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ITRN_SUPPLIERGEN3 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ITRN_SUPPLIERGEN3 ON Trn_SupplierGen (SG_LocationSupplierLocationId ,SG_LocationSupplierOrganisatio ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateTrn_Location( )
      {
         string cmdBuffer = "";
         /* Indices for table Trn_Location */
         try
         {
            cmdBuffer=" CREATE TABLE Trn_Location (LocationId CHAR(36) NOT NULL , OrganisationId CHAR(36) NOT NULL , LocationName VARCHAR(100) NOT NULL , LocationEmail VARCHAR(100) NOT NULL , LocationPhone CHAR(20) NOT NULL , LocationDescription TEXT NOT NULL , LocationCity VARCHAR(100) NOT NULL , LocationZipCode VARCHAR(100) NOT NULL , LocationAddressLine1 VARCHAR(100) NOT NULL , LocationAddressLine2 VARCHAR(100) NOT NULL , LocationPhoneCode VARCHAR(40) NOT NULL , LocationPhoneNumber VARCHAR(9) NOT NULL , LocationCountry VARCHAR(100) NOT NULL , LocationImage BYTEA , LocationImage_GXI VARCHAR(2048) , ToolBoxDefaultLogo VARCHAR(200) , ToolBoxDefaultProfileImage VARCHAR(200) , LocationBrandTheme TEXT , LocationCtaTheme TEXT , LocationHasMyCare BOOLEAN NOT NULL , LocationHasMyServices BOOLEAN NOT NULL , LocationHasMyLiving BOOLEAN NOT NULL , LocationHasOwnBrand BOOLEAN NOT NULL , ReceptionImage BYTEA , ReceptionImage_GXI VARCHAR(2048) , ReceptionDescription VARCHAR(200) , LocationThemeId CHAR(36) , ActiveAppVersionId CHAR(36) , PublishedActiveAppVersionId CHAR(36) , ToolBoxLastUpdateReceptionistI CHAR(36) , ToolBoxLastUpdateTime timestamp without time zone , PRIMARY KEY(LocationId, OrganisationId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE Trn_Location CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW Trn_Location CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION Trn_Location CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE Trn_Location (LocationId CHAR(36) NOT NULL , OrganisationId CHAR(36) NOT NULL , LocationName VARCHAR(100) NOT NULL , LocationEmail VARCHAR(100) NOT NULL , LocationPhone CHAR(20) NOT NULL , LocationDescription TEXT NOT NULL , LocationCity VARCHAR(100) NOT NULL , LocationZipCode VARCHAR(100) NOT NULL , LocationAddressLine1 VARCHAR(100) NOT NULL , LocationAddressLine2 VARCHAR(100) NOT NULL , LocationPhoneCode VARCHAR(40) NOT NULL , LocationPhoneNumber VARCHAR(9) NOT NULL , LocationCountry VARCHAR(100) NOT NULL , LocationImage BYTEA , LocationImage_GXI VARCHAR(2048) , ToolBoxDefaultLogo VARCHAR(200) , ToolBoxDefaultProfileImage VARCHAR(200) , LocationBrandTheme TEXT , LocationCtaTheme TEXT , LocationHasMyCare BOOLEAN NOT NULL , LocationHasMyServices BOOLEAN NOT NULL , LocationHasMyLiving BOOLEAN NOT NULL , LocationHasOwnBrand BOOLEAN NOT NULL , ReceptionImage BYTEA , ReceptionImage_GXI VARCHAR(2048) , ReceptionDescription VARCHAR(200) , LocationThemeId CHAR(36) , ActiveAppVersionId CHAR(36) , PublishedActiveAppVersionId CHAR(36) , ToolBoxLastUpdateReceptionistI CHAR(36) , ToolBoxLastUpdateTime timestamp without time zone , PRIMARY KEY(LocationId, OrganisationId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX UTRN_LOCATION ON Trn_Location (LocationName ,LocationEmail ,LocationPhone ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX UTRN_LOCATION "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX UTRN_LOCATION ON Trn_Location (LocationName ,LocationEmail ,LocationPhone ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ITRN_LOCATION3 ON Trn_Location (LocationThemeId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ITRN_LOCATION3 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ITRN_LOCATION3 ON Trn_Location (LocationThemeId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ITRN_LOCATION4 ON Trn_Location (ActiveAppVersionId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ITRN_LOCATION4 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ITRN_LOCATION4 ON Trn_Location (ActiveAppVersionId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ITRN_LOCATION5 ON Trn_Location (PublishedActiveAppVersionId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ITRN_LOCATION5 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ITRN_LOCATION5 ON Trn_Location (PublishedActiveAppVersionId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ITRN_LOCATION1 ON Trn_Location (ToolBoxLastUpdateReceptionistI ,OrganisationId ,LocationId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ITRN_LOCATION1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ITRN_LOCATION1 ON Trn_Location (ToolBoxLastUpdateReceptionistI ,OrganisationId ,LocationId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateTrn_Manager( )
      {
         string cmdBuffer = "";
         /* Indices for table Trn_Manager */
         try
         {
            cmdBuffer=" CREATE TABLE Trn_Manager (ManagerId CHAR(36) NOT NULL , OrganisationId CHAR(36) NOT NULL , ManagerGivenName VARCHAR(100) NOT NULL , ManagerLastName VARCHAR(100) NOT NULL , ManagerInitials CHAR(20) NOT NULL , ManagerEmail VARCHAR(100) NOT NULL , ManagerPhone CHAR(20) NOT NULL , ManagerGender VARCHAR(40) NOT NULL , ManagerGAMGUID VARCHAR(100) NOT NULL , ManagerIsMainManager BOOLEAN NOT NULL , ManagerPhoneCode VARCHAR(40) NOT NULL , ManagerPhoneNumber VARCHAR(9) NOT NULL , ManagerIsActive BOOLEAN NOT NULL , ManagerImage BYTEA NOT NULL , ManagerImage_GXI VARCHAR(2048) , PRIMARY KEY(ManagerId, OrganisationId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE Trn_Manager CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW Trn_Manager CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION Trn_Manager CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE Trn_Manager (ManagerId CHAR(36) NOT NULL , OrganisationId CHAR(36) NOT NULL , ManagerGivenName VARCHAR(100) NOT NULL , ManagerLastName VARCHAR(100) NOT NULL , ManagerInitials CHAR(20) NOT NULL , ManagerEmail VARCHAR(100) NOT NULL , ManagerPhone CHAR(20) NOT NULL , ManagerGender VARCHAR(40) NOT NULL , ManagerGAMGUID VARCHAR(100) NOT NULL , ManagerIsMainManager BOOLEAN NOT NULL , ManagerPhoneCode VARCHAR(40) NOT NULL , ManagerPhoneNumber VARCHAR(9) NOT NULL , ManagerIsActive BOOLEAN NOT NULL , ManagerImage BYTEA NOT NULL , ManagerImage_GXI VARCHAR(2048) , PRIMARY KEY(ManagerId, OrganisationId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ITRN_MANAGER1 ON Trn_Manager (OrganisationId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ITRN_MANAGER1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ITRN_MANAGER1 ON Trn_Manager (OrganisationId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateTrn_OrganisationType( )
      {
         string cmdBuffer = "";
         /* Indices for table Trn_OrganisationType */
         try
         {
            cmdBuffer=" CREATE TABLE Trn_OrganisationType (OrganisationTypeId CHAR(36) NOT NULL , OrganisationTypeName VARCHAR(100) NOT NULL , PRIMARY KEY(OrganisationTypeId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE Trn_OrganisationType CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW Trn_OrganisationType CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION Trn_OrganisationType CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE Trn_OrganisationType (OrganisationTypeId CHAR(36) NOT NULL , OrganisationTypeName VARCHAR(100) NOT NULL , PRIMARY KEY(OrganisationTypeId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateTrn_Organisation( )
      {
         string cmdBuffer = "";
         /* Indices for table Trn_Organisation */
         try
         {
            cmdBuffer=" CREATE TABLE Trn_Organisation (OrganisationId CHAR(36) NOT NULL , OrganisationKvkNumber VARCHAR(8) NOT NULL , OrganisationName VARCHAR(100) NOT NULL , OrganisationEmail VARCHAR(100) NOT NULL , OrganisationPhone CHAR(20) NOT NULL , OrganisationVATNumber VARCHAR(14) NOT NULL , OrganisationTypeId CHAR(36) NOT NULL , OrganisationAddressZipCode VARCHAR(100) NOT NULL , OrganisationAddressCity VARCHAR(100) NOT NULL , OrganisationAddressCountry VARCHAR(100) NOT NULL , OrganisationAddressLine1 VARCHAR(100) NOT NULL , OrganisationAddressLine2 VARCHAR(100) NOT NULL , OrganisationPhoneCode VARCHAR(40) NOT NULL , OrganisationPhoneNumber VARCHAR(9) NOT NULL , OrganisationLogo BYTEA NOT NULL , OrganisationLogo_GXI VARCHAR(2048) , PRIMARY KEY(OrganisationId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE Trn_Organisation CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW Trn_Organisation CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION Trn_Organisation CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE Trn_Organisation (OrganisationId CHAR(36) NOT NULL , OrganisationKvkNumber VARCHAR(8) NOT NULL , OrganisationName VARCHAR(100) NOT NULL , OrganisationEmail VARCHAR(100) NOT NULL , OrganisationPhone CHAR(20) NOT NULL , OrganisationVATNumber VARCHAR(14) NOT NULL , OrganisationTypeId CHAR(36) NOT NULL , OrganisationAddressZipCode VARCHAR(100) NOT NULL , OrganisationAddressCity VARCHAR(100) NOT NULL , OrganisationAddressCountry VARCHAR(100) NOT NULL , OrganisationAddressLine1 VARCHAR(100) NOT NULL , OrganisationAddressLine2 VARCHAR(100) NOT NULL , OrganisationPhoneCode VARCHAR(40) NOT NULL , OrganisationPhoneNumber VARCHAR(9) NOT NULL , OrganisationLogo BYTEA NOT NULL , OrganisationLogo_GXI VARCHAR(2048) , PRIMARY KEY(OrganisationId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ITRN_ORGANISATION1 ON Trn_Organisation (OrganisationTypeId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ITRN_ORGANISATION1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ITRN_ORGANISATION1 ON Trn_Organisation (OrganisationTypeId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX UTRN_ORGANISATION ON Trn_Organisation (OrganisationName ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX UTRN_ORGANISATION "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX UTRN_ORGANISATION ON Trn_Organisation (OrganisationName ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RITrn_OrganisationTrn_OrganisationType( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Trn_Organisation ADD CONSTRAINT ITRN_ORGANISATION1 FOREIGN KEY (OrganisationTypeId) REFERENCES Trn_OrganisationType (OrganisationTypeId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Trn_Organisation DROP CONSTRAINT ITRN_ORGANISATION1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Trn_Organisation ADD CONSTRAINT ITRN_ORGANISATION1 FOREIGN KEY (OrganisationTypeId) REFERENCES Trn_OrganisationType (OrganisationTypeId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RITrn_ManagerTrn_Organisation( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Trn_Manager ADD CONSTRAINT ITRN_MANAGER1 FOREIGN KEY (OrganisationId) REFERENCES Trn_Organisation (OrganisationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Trn_Manager DROP CONSTRAINT ITRN_MANAGER1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Trn_Manager ADD CONSTRAINT ITRN_MANAGER1 FOREIGN KEY (OrganisationId) REFERENCES Trn_Organisation (OrganisationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RITrn_LocationTrn_Receptionist( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Trn_Location ADD CONSTRAINT ITRN_LOCATION1 FOREIGN KEY (ToolBoxLastUpdateReceptionistI, OrganisationId, LocationId) REFERENCES Trn_Receptionist (ReceptionistId, OrganisationId, LocationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Trn_Location DROP CONSTRAINT ITRN_LOCATION1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Trn_Location ADD CONSTRAINT ITRN_LOCATION1 FOREIGN KEY (ToolBoxLastUpdateReceptionistI, OrganisationId, LocationId) REFERENCES Trn_Receptionist (ReceptionistId, OrganisationId, LocationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RITrn_LocationTrn_Theme( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Trn_Location ADD CONSTRAINT ITRN_LOCATION3 FOREIGN KEY (LocationThemeId) REFERENCES Trn_Theme (Trn_ThemeId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Trn_Location DROP CONSTRAINT ITRN_LOCATION3 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Trn_Location ADD CONSTRAINT ITRN_LOCATION3 FOREIGN KEY (LocationThemeId) REFERENCES Trn_Theme (Trn_ThemeId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RITrn_LocationTrn_AppVersion( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Trn_Location ADD CONSTRAINT ITRN_LOCATION5 FOREIGN KEY (PublishedActiveAppVersionId) REFERENCES Trn_AppVersion (AppVersionId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Trn_Location DROP CONSTRAINT ITRN_LOCATION5 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Trn_Location ADD CONSTRAINT ITRN_LOCATION5 FOREIGN KEY (PublishedActiveAppVersionId) REFERENCES Trn_AppVersion (AppVersionId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RITrn_LocationTrn_AppVersion1( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Trn_Location ADD CONSTRAINT ITRN_LOCATION4 FOREIGN KEY (ActiveAppVersionId) REFERENCES Trn_AppVersion (AppVersionId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Trn_Location DROP CONSTRAINT ITRN_LOCATION4 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Trn_Location ADD CONSTRAINT ITRN_LOCATION4 FOREIGN KEY (ActiveAppVersionId) REFERENCES Trn_AppVersion (AppVersionId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RITrn_SupplierGenTrn_SupplierGenType( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Trn_SupplierGen ADD CONSTRAINT ITRN_SUPPLIERGEN1 FOREIGN KEY (SupplierGenTypeId) REFERENCES Trn_SupplierGenType (SupplierGenTypeId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Trn_SupplierGen DROP CONSTRAINT ITRN_SUPPLIERGEN1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Trn_SupplierGen ADD CONSTRAINT ITRN_SUPPLIERGEN1 FOREIGN KEY (SupplierGenTypeId) REFERENCES Trn_SupplierGenType (SupplierGenTypeId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RITrn_SupplierGenTrn_Location( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Trn_SupplierGen ADD CONSTRAINT ITRN_SUPPLIERGEN3 FOREIGN KEY (SG_LocationSupplierLocationId, SG_LocationSupplierOrganisatio) REFERENCES Trn_Location (LocationId, OrganisationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Trn_SupplierGen DROP CONSTRAINT ITRN_SUPPLIERGEN3 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Trn_SupplierGen ADD CONSTRAINT ITRN_SUPPLIERGEN3 FOREIGN KEY (SG_LocationSupplierLocationId, SG_LocationSupplierOrganisatio) REFERENCES Trn_Location (LocationId, OrganisationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RITrn_SupplierGenTrn_Organisation( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Trn_SupplierGen ADD CONSTRAINT ITRN_SUPPLIERGEN2 FOREIGN KEY (SG_OrganisationSupplierId) REFERENCES Trn_Organisation (OrganisationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Trn_SupplierGen DROP CONSTRAINT ITRN_SUPPLIERGEN2 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Trn_SupplierGen ADD CONSTRAINT ITRN_SUPPLIERGEN2 FOREIGN KEY (SG_OrganisationSupplierId) REFERENCES Trn_Organisation (OrganisationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RITrn_SupplierAGBTrn_SupplierAgbType( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Trn_SupplierAGB ADD CONSTRAINT ITRN_SUPPLIERAGB1 FOREIGN KEY (SupplierAgbTypeId) REFERENCES Trn_SupplierAgbType (SupplierAgbTypeId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Trn_SupplierAGB DROP CONSTRAINT ITRN_SUPPLIERAGB1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Trn_SupplierAGB ADD CONSTRAINT ITRN_SUPPLIERAGB1 FOREIGN KEY (SupplierAgbTypeId) REFERENCES Trn_SupplierAgbType (SupplierAgbTypeId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIWWP_SubscriptionWWP_NotificationDefinition( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE WWP_Subscription ADD CONSTRAINT IWWP_SUBSCRIPTION2 FOREIGN KEY (WWPNotificationDefinitionId) REFERENCES WWP_NotificationDefinition (WWPNotificationDefinitionId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE WWP_Subscription DROP CONSTRAINT IWWP_SUBSCRIPTION2 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE WWP_Subscription ADD CONSTRAINT IWWP_SUBSCRIPTION2 FOREIGN KEY (WWPNotificationDefinitionId) REFERENCES WWP_NotificationDefinition (WWPNotificationDefinitionId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIWWP_SubscriptionWWP_UserExtended( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE WWP_Subscription ADD CONSTRAINT IWWP_SUBSCRIPTION1 FOREIGN KEY (WWPUserExtendedId) REFERENCES WWP_UserExtended (WWPUserExtendedId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE WWP_Subscription DROP CONSTRAINT IWWP_SUBSCRIPTION1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE WWP_Subscription ADD CONSTRAINT IWWP_SUBSCRIPTION1 FOREIGN KEY (WWPUserExtendedId) REFERENCES WWP_UserExtended (WWPUserExtendedId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIWWP_SMSWWP_Notification( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE WWP_SMS ADD CONSTRAINT IWWP_SMS1 FOREIGN KEY (WWPNotificationId) REFERENCES WWP_Notification (WWPNotificationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE WWP_SMS DROP CONSTRAINT IWWP_SMS1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE WWP_SMS ADD CONSTRAINT IWWP_SMS1 FOREIGN KEY (WWPNotificationId) REFERENCES WWP_Notification (WWPNotificationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIWWP_WebNotificationWWP_Notification( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE WWP_WebNotification ADD CONSTRAINT IWWP_WEBNOTIFICATION1 FOREIGN KEY (WWPNotificationId) REFERENCES WWP_Notification (WWPNotificationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE WWP_WebNotification DROP CONSTRAINT IWWP_WEBNOTIFICATION1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE WWP_WebNotification ADD CONSTRAINT IWWP_WEBNOTIFICATION1 FOREIGN KEY (WWPNotificationId) REFERENCES WWP_Notification (WWPNotificationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIWWP_WebClientWWP_UserExtended( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE WWP_WebClient ADD CONSTRAINT IWWP_WEBCLIENT1 FOREIGN KEY (WWPUserExtendedId) REFERENCES WWP_UserExtended (WWPUserExtendedId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE WWP_WebClient DROP CONSTRAINT IWWP_WEBCLIENT1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE WWP_WebClient ADD CONSTRAINT IWWP_WEBCLIENT1 FOREIGN KEY (WWPUserExtendedId) REFERENCES WWP_UserExtended (WWPUserExtendedId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIWWP_NotificationDefinitionWWP_Entity( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE WWP_NotificationDefinition ADD CONSTRAINT IWWP_NOTIFICATIONDEFINITION1 FOREIGN KEY (WWPEntityId) REFERENCES WWP_Entity (WWPEntityId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE WWP_NotificationDefinition DROP CONSTRAINT IWWP_NOTIFICATIONDEFINITION1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE WWP_NotificationDefinition ADD CONSTRAINT IWWP_NOTIFICATIONDEFINITION1 FOREIGN KEY (WWPEntityId) REFERENCES WWP_Entity (WWPEntityId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIWWP_NotificationWWP_NotificationDefinition( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE WWP_Notification ADD CONSTRAINT IWWP_NOTIFICATION2 FOREIGN KEY (WWPNotificationDefinitionId) REFERENCES WWP_NotificationDefinition (WWPNotificationDefinitionId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE WWP_Notification DROP CONSTRAINT IWWP_NOTIFICATION2 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE WWP_Notification ADD CONSTRAINT IWWP_NOTIFICATION2 FOREIGN KEY (WWPNotificationDefinitionId) REFERENCES WWP_NotificationDefinition (WWPNotificationDefinitionId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIWWP_NotificationWWP_UserExtended( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE WWP_Notification ADD CONSTRAINT IWWP_NOTIFICATION1 FOREIGN KEY (WWPUserExtendedId) REFERENCES WWP_UserExtended (WWPUserExtendedId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE WWP_Notification DROP CONSTRAINT IWWP_NOTIFICATION1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE WWP_Notification ADD CONSTRAINT IWWP_NOTIFICATION1 FOREIGN KEY (WWPUserExtendedId) REFERENCES WWP_UserExtended (WWPUserExtendedId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIWWP_MailWWP_Notification( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE WWP_Mail ADD CONSTRAINT IWWP_MAIL1 FOREIGN KEY (WWPNotificationId) REFERENCES WWP_Notification (WWPNotificationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE WWP_Mail DROP CONSTRAINT IWWP_MAIL1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE WWP_Mail ADD CONSTRAINT IWWP_MAIL1 FOREIGN KEY (WWPNotificationId) REFERENCES WWP_Notification (WWPNotificationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIWWP_MailAttachmentsWWP_Mail( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE WWP_MailAttachments ADD CONSTRAINT IWWP_MAILATTACHMENTS1 FOREIGN KEY (WWPMailId) REFERENCES WWP_Mail (WWPMailId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE WWP_MailAttachments DROP CONSTRAINT IWWP_MAILATTACHMENTS1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE WWP_MailAttachments ADD CONSTRAINT IWWP_MAILATTACHMENTS1 FOREIGN KEY (WWPMailId) REFERENCES WWP_Mail (WWPMailId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIWWP_DiscussionMessageWWP_UserExtended( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE WWP_DiscussionMessage ADD CONSTRAINT IWWP_DISCUSSIONMESSAGE3 FOREIGN KEY (WWPUserExtendedId) REFERENCES WWP_UserExtended (WWPUserExtendedId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE WWP_DiscussionMessage DROP CONSTRAINT IWWP_DISCUSSIONMESSAGE3 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE WWP_DiscussionMessage ADD CONSTRAINT IWWP_DISCUSSIONMESSAGE3 FOREIGN KEY (WWPUserExtendedId) REFERENCES WWP_UserExtended (WWPUserExtendedId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIWWP_DiscussionMessageWWP_Entity( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE WWP_DiscussionMessage ADD CONSTRAINT IWWP_DISCUSSIONMESSAGE2 FOREIGN KEY (WWPEntityId) REFERENCES WWP_Entity (WWPEntityId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE WWP_DiscussionMessage DROP CONSTRAINT IWWP_DISCUSSIONMESSAGE2 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE WWP_DiscussionMessage ADD CONSTRAINT IWWP_DISCUSSIONMESSAGE2 FOREIGN KEY (WWPEntityId) REFERENCES WWP_Entity (WWPEntityId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIWWP_DiscussionMessageWWP_DiscussionMessage( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE WWP_DiscussionMessage ADD CONSTRAINT IWWP_DISCUSSIONMESSAGE1 FOREIGN KEY (WWPDiscussionMessageThreadId) REFERENCES WWP_DiscussionMessage (WWPDiscussionMessageId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE WWP_DiscussionMessage DROP CONSTRAINT IWWP_DISCUSSIONMESSAGE1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE WWP_DiscussionMessage ADD CONSTRAINT IWWP_DISCUSSIONMESSAGE1 FOREIGN KEY (WWPDiscussionMessageThreadId) REFERENCES WWP_DiscussionMessage (WWPDiscussionMessageId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIWWP_DiscussionMessageMentionWWP_DiscussionMessage( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE WWP_DiscussionMessageMention ADD CONSTRAINT IWWP_DISCUSSIONMESSAGEMENTION2 FOREIGN KEY (WWPDiscussionMessageId) REFERENCES WWP_DiscussionMessage (WWPDiscussionMessageId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE WWP_DiscussionMessageMention DROP CONSTRAINT IWWP_DISCUSSIONMESSAGEMENTION2 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE WWP_DiscussionMessageMention ADD CONSTRAINT IWWP_DISCUSSIONMESSAGEMENTION2 FOREIGN KEY (WWPDiscussionMessageId) REFERENCES WWP_DiscussionMessage (WWPDiscussionMessageId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIWWP_DiscussionMessageMentionWWP_UserExtended( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE WWP_DiscussionMessageMention ADD CONSTRAINT IWWP_DISCUSSIONMESSAGEMENTION1 FOREIGN KEY (WWPDiscussionMentionUserId) REFERENCES WWP_UserExtended (WWPUserExtendedId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE WWP_DiscussionMessageMention DROP CONSTRAINT IWWP_DISCUSSIONMESSAGEMENTION1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE WWP_DiscussionMessageMention ADD CONSTRAINT IWWP_DISCUSSIONMESSAGEMENTION1 FOREIGN KEY (WWPDiscussionMentionUserId) REFERENCES WWP_UserExtended (WWPUserExtendedId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIWWP_FormElementWWP_FormElement( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE WWP_FormElement ADD CONSTRAINT IWWPFORMELEMENT1 FOREIGN KEY (WWPFormId, WWPFormVersionNumber, WWPFormElementParentId) REFERENCES WWP_FormElement (WWPFormId, WWPFormVersionNumber, WWPFormElementId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE WWP_FormElement DROP CONSTRAINT IWWPFORMELEMENT1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE WWP_FormElement ADD CONSTRAINT IWWPFORMELEMENT1 FOREIGN KEY (WWPFormId, WWPFormVersionNumber, WWPFormElementParentId) REFERENCES WWP_FormElement (WWPFormId, WWPFormVersionNumber, WWPFormElementId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIWWP_FormInstanceWWP_Form( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE WWP_FormInstance ADD CONSTRAINT IWWPFORMINSTANCE1 FOREIGN KEY (WWPFormId, WWPFormVersionNumber) REFERENCES WWP_Form (WWPFormId, WWPFormVersionNumber) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE WWP_FormInstance DROP CONSTRAINT IWWPFORMINSTANCE1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE WWP_FormInstance ADD CONSTRAINT IWWPFORMINSTANCE1 FOREIGN KEY (WWPFormId, WWPFormVersionNumber) REFERENCES WWP_Form (WWPFormId, WWPFormVersionNumber) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIWWP_FormInstanceWWP_UserExtended( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE WWP_FormInstance ADD CONSTRAINT IWWP_FORMINSTANCE FOREIGN KEY (WWPUserExtendedId) REFERENCES WWP_UserExtended (WWPUserExtendedId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE WWP_FormInstance DROP CONSTRAINT IWWP_FORMINSTANCE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE WWP_FormInstance ADD CONSTRAINT IWWP_FORMINSTANCE FOREIGN KEY (WWPUserExtendedId) REFERENCES WWP_UserExtended (WWPUserExtendedId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIWWP_FormInstanceElementWWP_FormInstance( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE WWP_FormInstanceElement ADD CONSTRAINT IWWPFORMINSTANCEELEMENT1 FOREIGN KEY (WWPFormInstanceId) REFERENCES WWP_FormInstance (WWPFormInstanceId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE WWP_FormInstanceElement DROP CONSTRAINT IWWPFORMINSTANCEELEMENT1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE WWP_FormInstanceElement ADD CONSTRAINT IWWPFORMINSTANCEELEMENT1 FOREIGN KEY (WWPFormInstanceId) REFERENCES WWP_FormInstance (WWPFormInstanceId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RITrn_AgendaCalendarTrn_Location( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Trn_AgendaCalendar ADD CONSTRAINT ITRN_AGENDACALENDAR1 FOREIGN KEY (LocationId, OrganisationId) REFERENCES Trn_Location (LocationId, OrganisationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Trn_AgendaCalendar DROP CONSTRAINT ITRN_AGENDACALENDAR1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Trn_AgendaCalendar ADD CONSTRAINT ITRN_AGENDACALENDAR1 FOREIGN KEY (LocationId, OrganisationId) REFERENCES Trn_Location (LocationId, OrganisationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RITrn_ThemeColorTrn_Theme( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Trn_ThemeColor ADD CONSTRAINT ITRN_THEMECOLOR1 FOREIGN KEY (Trn_ThemeId) REFERENCES Trn_Theme (Trn_ThemeId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Trn_ThemeColor DROP CONSTRAINT ITRN_THEMECOLOR1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Trn_ThemeColor ADD CONSTRAINT ITRN_THEMECOLOR1 FOREIGN KEY (Trn_ThemeId) REFERENCES Trn_Theme (Trn_ThemeId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RITrn_ReceptionistTrn_Location( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Trn_Receptionist ADD CONSTRAINT ITRN_RECEPTIONIST1 FOREIGN KEY (LocationId, OrganisationId) REFERENCES Trn_Location (LocationId, OrganisationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Trn_Receptionist DROP CONSTRAINT ITRN_RECEPTIONIST1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Trn_Receptionist ADD CONSTRAINT ITRN_RECEPTIONIST1 FOREIGN KEY (LocationId, OrganisationId) REFERENCES Trn_Location (LocationId, OrganisationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RITrn_ResidentTrn_Location( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Trn_Resident ADD CONSTRAINT ITRN_RESIDENT4 FOREIGN KEY (LocationId, OrganisationId) REFERENCES Trn_Location (LocationId, OrganisationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Trn_Resident DROP CONSTRAINT ITRN_RESIDENT4 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Trn_Resident ADD CONSTRAINT ITRN_RESIDENT4 FOREIGN KEY (LocationId, OrganisationId) REFERENCES Trn_Location (LocationId, OrganisationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RITrn_ResidentTrn_ResidentType( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Trn_Resident ADD CONSTRAINT ITRN_RESIDENT3 FOREIGN KEY (ResidentTypeId) REFERENCES Trn_ResidentType (ResidentTypeId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Trn_Resident DROP CONSTRAINT ITRN_RESIDENT3 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Trn_Resident ADD CONSTRAINT ITRN_RESIDENT3 FOREIGN KEY (ResidentTypeId) REFERENCES Trn_ResidentType (ResidentTypeId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RITrn_ResidentTrn_MedicalIndication( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Trn_Resident ADD CONSTRAINT ITRN_RESIDENT2 FOREIGN KEY (MedicalIndicationId) REFERENCES Trn_MedicalIndication (MedicalIndicationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Trn_Resident DROP CONSTRAINT ITRN_RESIDENT2 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Trn_Resident ADD CONSTRAINT ITRN_RESIDENT2 FOREIGN KEY (MedicalIndicationId) REFERENCES Trn_MedicalIndication (MedicalIndicationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RITrn_ResidentTrn_ResidentPackage( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Trn_Resident ADD CONSTRAINT ITRN_RESIDENT1 FOREIGN KEY (ResidentPackageId) REFERENCES Trn_ResidentPackage (ResidentPackageId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Trn_Resident DROP CONSTRAINT ITRN_RESIDENT1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Trn_Resident ADD CONSTRAINT ITRN_RESIDENT1 FOREIGN KEY (ResidentPackageId) REFERENCES Trn_ResidentPackage (ResidentPackageId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RITrn_ProductServiceTrn_Location( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Trn_ProductService ADD CONSTRAINT ITRN_PRODUCTSERVICE3 FOREIGN KEY (LocationId, OrganisationId) REFERENCES Trn_Location (LocationId, OrganisationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Trn_ProductService DROP CONSTRAINT ITRN_PRODUCTSERVICE3 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Trn_ProductService ADD CONSTRAINT ITRN_PRODUCTSERVICE3 FOREIGN KEY (LocationId, OrganisationId) REFERENCES Trn_Location (LocationId, OrganisationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RITrn_ProductServiceTrn_SupplierGen( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Trn_ProductService ADD CONSTRAINT ITRN_PRODUCTSERVICE2 FOREIGN KEY (SupplierGenId) REFERENCES Trn_SupplierGen (SupplierGenId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Trn_ProductService DROP CONSTRAINT ITRN_PRODUCTSERVICE2 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Trn_ProductService ADD CONSTRAINT ITRN_PRODUCTSERVICE2 FOREIGN KEY (SupplierGenId) REFERENCES Trn_SupplierGen (SupplierGenId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RITrn_ProductServiceTrn_SupplierAGB( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Trn_ProductService ADD CONSTRAINT ITRN_PRODUCTSERVICE1 FOREIGN KEY (SupplierAgbId) REFERENCES Trn_SupplierAGB (SupplierAgbId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Trn_ProductService DROP CONSTRAINT ITRN_PRODUCTSERVICE1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Trn_ProductService ADD CONSTRAINT ITRN_PRODUCTSERVICE1 FOREIGN KEY (SupplierAgbId) REFERENCES Trn_SupplierAGB (SupplierAgbId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RITrn_LocationDynamicFormTrn_Location( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Trn_LocationDynamicForm ADD CONSTRAINT ITRN_LOCATIONDYNAMICFORM2 FOREIGN KEY (LocationId, OrganisationId) REFERENCES Trn_Location (LocationId, OrganisationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Trn_LocationDynamicForm DROP CONSTRAINT ITRN_LOCATIONDYNAMICFORM2 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Trn_LocationDynamicForm ADD CONSTRAINT ITRN_LOCATIONDYNAMICFORM2 FOREIGN KEY (LocationId, OrganisationId) REFERENCES Trn_Location (LocationId, OrganisationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RITrn_LocationDynamicFormWWP_Form( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Trn_LocationDynamicForm ADD CONSTRAINT ITRN_LOCATIONDYNAMICFORM1 FOREIGN KEY (WWPFormId, WWPFormVersionNumber) REFERENCES WWP_Form (WWPFormId, WWPFormVersionNumber) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Trn_LocationDynamicForm DROP CONSTRAINT ITRN_LOCATIONDYNAMICFORM1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Trn_LocationDynamicForm ADD CONSTRAINT ITRN_LOCATIONDYNAMICFORM1 FOREIGN KEY (WWPFormId, WWPFormVersionNumber) REFERENCES WWP_Form (WWPFormId, WWPFormVersionNumber) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RITrn_CallToActionTrn_ProductService( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Trn_CallToAction ADD CONSTRAINT ITRN_CALLTOACTION2 FOREIGN KEY (ProductServiceId, LocationId, OrganisationId) REFERENCES Trn_ProductService (ProductServiceId, LocationId, OrganisationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Trn_CallToAction DROP CONSTRAINT ITRN_CALLTOACTION2 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Trn_CallToAction ADD CONSTRAINT ITRN_CALLTOACTION2 FOREIGN KEY (ProductServiceId, LocationId, OrganisationId) REFERENCES Trn_ProductService (ProductServiceId, LocationId, OrganisationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RITrn_CallToActionTrn_LocationDynamicForm( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Trn_CallToAction ADD CONSTRAINT ITRN_CALLTOACTION1 FOREIGN KEY (LocationDynamicFormId, OrganisationId, LocationId) REFERENCES Trn_LocationDynamicForm (LocationDynamicFormId, OrganisationId, LocationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Trn_CallToAction DROP CONSTRAINT ITRN_CALLTOACTION1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Trn_CallToAction ADD CONSTRAINT ITRN_CALLTOACTION1 FOREIGN KEY (LocationDynamicFormId, OrganisationId, LocationId) REFERENCES Trn_LocationDynamicForm (LocationDynamicFormId, OrganisationId, LocationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RITrn_AuditTrn_Organisation( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Trn_Audit ADD CONSTRAINT ITRN_AUDIT FOREIGN KEY (OrganisationId) REFERENCES Trn_Organisation (OrganisationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Trn_Audit DROP CONSTRAINT ITRN_AUDIT "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Trn_Audit ADD CONSTRAINT ITRN_AUDIT FOREIGN KEY (OrganisationId) REFERENCES Trn_Organisation (OrganisationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RITrn_ThemeIconTrn_Theme( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Trn_ThemeIcon ADD CONSTRAINT ITRN_THEMEICON1 FOREIGN KEY (Trn_ThemeId) REFERENCES Trn_Theme (Trn_ThemeId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Trn_ThemeIcon DROP CONSTRAINT ITRN_THEMEICON1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Trn_ThemeIcon ADD CONSTRAINT ITRN_THEMEICON1 FOREIGN KEY (Trn_ThemeId) REFERENCES Trn_Theme (Trn_ThemeId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RITrn_AgendaEventGroupTrn_AgendaCalendar( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Trn_AgendaEventGroup ADD CONSTRAINT ITRN_AGENDAEVENTGROUP1 FOREIGN KEY (AgendaCalendarId) REFERENCES Trn_AgendaCalendar (AgendaCalendarId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Trn_AgendaEventGroup DROP CONSTRAINT ITRN_AGENDAEVENTGROUP1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Trn_AgendaEventGroup ADD CONSTRAINT ITRN_AGENDAEVENTGROUP1 FOREIGN KEY (AgendaCalendarId) REFERENCES Trn_AgendaCalendar (AgendaCalendarId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RITrn_ResidentNotificationTrn_AppNotification( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Trn_ResidentNotification ADD CONSTRAINT ITRN_RESIDENTNOTIFICATION1 FOREIGN KEY (AppNotificationId) REFERENCES Trn_AppNotification (AppNotificationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Trn_ResidentNotification DROP CONSTRAINT ITRN_RESIDENTNOTIFICATION1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Trn_ResidentNotification ADD CONSTRAINT ITRN_RESIDENTNOTIFICATION1 FOREIGN KEY (AppNotificationId) REFERENCES Trn_AppNotification (AppNotificationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RITrn_PageTrn_Location( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Trn_Page ADD CONSTRAINT GX_002G000B000T FOREIGN KEY (LocationId, OrganisationId) REFERENCES Trn_Location (LocationId, OrganisationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Trn_Page DROP CONSTRAINT GX_002G000B000T "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Trn_Page ADD CONSTRAINT GX_002G000B000T FOREIGN KEY (LocationId, OrganisationId) REFERENCES Trn_Location (LocationId, OrganisationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RITrn_PageTrn_ProductService( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Trn_Page ADD CONSTRAINT ITRN_PAGE1 FOREIGN KEY (ProductServiceId, LocationId, OrganisationId) REFERENCES Trn_ProductService (ProductServiceId, LocationId, OrganisationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Trn_Page DROP CONSTRAINT ITRN_PAGE1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Trn_Page ADD CONSTRAINT ITRN_PAGE1 FOREIGN KEY (ProductServiceId, LocationId, OrganisationId) REFERENCES Trn_ProductService (ProductServiceId, LocationId, OrganisationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RITrn_OrganisationDynamicFormTrn_Organisation( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Trn_OrganisationDynamicForm ADD CONSTRAINT ITRN_ORGANISATIONDYNAMICFORM2 FOREIGN KEY (OrganisationId) REFERENCES Trn_Organisation (OrganisationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Trn_OrganisationDynamicForm DROP CONSTRAINT ITRN_ORGANISATIONDYNAMICFORM2 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Trn_OrganisationDynamicForm ADD CONSTRAINT ITRN_ORGANISATIONDYNAMICFORM2 FOREIGN KEY (OrganisationId) REFERENCES Trn_Organisation (OrganisationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RITrn_OrganisationDynamicFormWWP_Form( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Trn_OrganisationDynamicForm ADD CONSTRAINT ITRN_ORGANISATIONDYNAMICFORM1 FOREIGN KEY (WWPFormId, WWPFormVersionNumber) REFERENCES WWP_Form (WWPFormId, WWPFormVersionNumber) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Trn_OrganisationDynamicForm DROP CONSTRAINT ITRN_ORGANISATIONDYNAMICFORM1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Trn_OrganisationDynamicForm ADD CONSTRAINT ITRN_ORGANISATIONDYNAMICFORM1 FOREIGN KEY (WWPFormId, WWPFormVersionNumber) REFERENCES WWP_Form (WWPFormId, WWPFormVersionNumber) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RITrn_OrganisationSettingTrn_Organisation( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Trn_OrganisationSetting ADD CONSTRAINT ITRN_ORGANISATIONSETTING1 FOREIGN KEY (OrganisationId) REFERENCES Trn_Organisation (OrganisationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Trn_OrganisationSetting DROP CONSTRAINT ITRN_ORGANISATIONSETTING1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Trn_OrganisationSetting ADD CONSTRAINT ITRN_ORGANISATIONSETTING1 FOREIGN KEY (OrganisationId) REFERENCES Trn_Organisation (OrganisationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RITrn_OrganisationSettingTrn_Theme( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Trn_OrganisationSetting ADD CONSTRAINT ITRN_ORGANISATIONSETTING2 FOREIGN KEY (Trn_ThemeId) REFERENCES Trn_Theme (Trn_ThemeId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Trn_OrganisationSetting DROP CONSTRAINT ITRN_ORGANISATIONSETTING2 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Trn_OrganisationSetting ADD CONSTRAINT ITRN_ORGANISATIONSETTING2 FOREIGN KEY (Trn_ThemeId) REFERENCES Trn_Theme (Trn_ThemeId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RITrn_AppVersionTrn_Location( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Trn_AppVersion ADD CONSTRAINT ITRN_APPVERSION1 FOREIGN KEY (LocationId, OrganisationId) REFERENCES Trn_Location (LocationId, OrganisationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Trn_AppVersion DROP CONSTRAINT ITRN_APPVERSION1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Trn_AppVersion ADD CONSTRAINT ITRN_APPVERSION1 FOREIGN KEY (LocationId, OrganisationId) REFERENCES Trn_Location (LocationId, OrganisationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RITrn_AppVersionTrn_Theme( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Trn_AppVersion ADD CONSTRAINT ITRN_APPVERSION2 FOREIGN KEY (Trn_ThemeId) REFERENCES Trn_Theme (Trn_ThemeId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Trn_AppVersion DROP CONSTRAINT ITRN_APPVERSION2 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Trn_AppVersion ADD CONSTRAINT ITRN_APPVERSION2 FOREIGN KEY (Trn_ThemeId) REFERENCES Trn_Theme (Trn_ThemeId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RITrn_AppVersionPageTrn_AppVersion( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Trn_AppVersionPage ADD CONSTRAINT ITRN_APPVERSIONPAGE2 FOREIGN KEY (AppVersionId) REFERENCES Trn_AppVersion (AppVersionId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Trn_AppVersionPage DROP CONSTRAINT ITRN_APPVERSIONPAGE2 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Trn_AppVersionPage ADD CONSTRAINT ITRN_APPVERSIONPAGE2 FOREIGN KEY (AppVersionId) REFERENCES Trn_AppVersion (AppVersionId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RITrn_ResidentPackageTrn_Location( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Trn_ResidentPackage ADD CONSTRAINT ITRN_RESIDENTPACKAGE1 FOREIGN KEY (SG_LocationId, SG_OrganisationId) REFERENCES Trn_Location (LocationId, OrganisationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Trn_ResidentPackage DROP CONSTRAINT ITRN_RESIDENTPACKAGE1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Trn_ResidentPackage ADD CONSTRAINT ITRN_RESIDENTPACKAGE1 FOREIGN KEY (SG_LocationId, SG_OrganisationId) REFERENCES Trn_Location (LocationId, OrganisationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RITrn_ThemeCtaColorTrn_Theme( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Trn_ThemeCtaColor ADD CONSTRAINT ITRN_THEMECTACOLOR1 FOREIGN KEY (Trn_ThemeId) REFERENCES Trn_Theme (Trn_ThemeId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Trn_ThemeCtaColor DROP CONSTRAINT ITRN_THEMECTACOLOR1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Trn_ThemeCtaColor ADD CONSTRAINT ITRN_THEMECTACOLOR1 FOREIGN KEY (Trn_ThemeId) REFERENCES Trn_Theme (Trn_ThemeId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RITrn_MemoTrn_Resident( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Trn_Memo ADD CONSTRAINT ITRN_MEMO2 FOREIGN KEY (ResidentId, SG_LocationId, SG_OrganisationId) REFERENCES Trn_Resident (ResidentId, LocationId, OrganisationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Trn_Memo DROP CONSTRAINT ITRN_MEMO2 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Trn_Memo ADD CONSTRAINT ITRN_MEMO2 FOREIGN KEY (ResidentId, SG_LocationId, SG_OrganisationId) REFERENCES Trn_Resident (ResidentId, LocationId, OrganisationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RITrn_SupplierDynamicFormTrn_SupplierGen( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Trn_SupplierDynamicForm ADD CONSTRAINT ITRN_SUPPLIERDYNAMICFORM2 FOREIGN KEY (SupplierGenId) REFERENCES Trn_SupplierGen (SupplierGenId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Trn_SupplierDynamicForm DROP CONSTRAINT ITRN_SUPPLIERDYNAMICFORM2 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Trn_SupplierDynamicForm ADD CONSTRAINT ITRN_SUPPLIERDYNAMICFORM2 FOREIGN KEY (SupplierGenId) REFERENCES Trn_SupplierGen (SupplierGenId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RITrn_SupplierDynamicFormWWP_Form( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Trn_SupplierDynamicForm ADD CONSTRAINT ITRN_SUPPLIERDYNAMICFORM1 FOREIGN KEY (WWPFormId, WWPFormVersionNumber) REFERENCES WWP_Form (WWPFormId, WWPFormVersionNumber) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Trn_SupplierDynamicForm DROP CONSTRAINT ITRN_SUPPLIERDYNAMICFORM1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Trn_SupplierDynamicForm ADD CONSTRAINT ITRN_SUPPLIERDYNAMICFORM1 FOREIGN KEY (WWPFormId, WWPFormVersionNumber) REFERENCES WWP_Form (WWPFormId, WWPFormVersionNumber) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      private void TablesCount( )
      {
      }

      private bool PreviousCheck( )
      {
         if ( ! MustRunCheck( ) )
         {
            return true ;
         }
         sSchemaVar = GXUtil.UserId( "Server", context, pr_default);
         return true ;
      }

      private void ExecuteOnlyTablesReorganization( )
      {
         ReorgExecute.RegisterBlockForSubmit( 1 ,  "CreateTrn_EnvironmentVariable" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 2 ,  "CreateTrn_SupplierDynamicForm" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 3 ,  "CreateTrn_LocationImage" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 4 ,  "CreateTrn_ServiceImage" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 5 ,  "CreateTrn_DiscussionTranslation" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 6 ,  "CreateTrn_DynamicFormTranslation" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 7 ,  "CreateTrn_DynamicTranslation" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 8 ,  "CreateTrn_Memo" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 9 ,  "CreateTrn_MemoCategory" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 10 ,  "CreateTrn_ThemeCtaColor" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 11 ,  "CreateTrn_ResidentPackage" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 12 ,  "CreateTrn_AppVersionPage" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 13 ,  "CreateTrn_AppVersion" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 14 ,  "CreateTrn_OrganisationSetting" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 15 ,  "CreateTrn_OrganisationDynamicForm" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 16 ,  "CreateTrn_Page" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 17 ,  "CreateTrn_ResidentNotification" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 18 ,  "CreateTrn_AppNotification" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 19 ,  "CreateTrn_AgendaEventGroup" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 20 ,  "CreateTrn_ThemeIcon" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 21 ,  "CreateTrn_Media" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 22 ,  "CreateTrn_PreferredGenSupplier" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 23 ,  "CreateTrn_PreferredAgbSupplier" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 24 ,  "CreateTrn_Audit" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 25 ,  "CreateTrn_CallToAction" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 26 ,  "CreateTrn_LocationDynamicForm" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 27 ,  "CreateTrn_ProductService" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 28 ,  "CreateTrn_Device" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 29 ,  "CreateTrn_Resident" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 30 ,  "CreateTrn_Receptionist" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 31 ,  "CreateTrn_Template" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 32 ,  "CreateTrn_ThemeColor" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 33 ,  "CreateTrn_Theme" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 34 ,  "CreateTrn_AgendaCalendar" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 35 ,  "CreateTrn_SupplierGenType" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 36 ,  "CreateTrn_SupplierAgbType" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 37 ,  "CreateUserCustomizations" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 38 ,  "CreateWWP_FormInstanceElement" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 39 ,  "CreateWWP_FormInstance" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 40 ,  "CreateWWP_FormElement" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 41 ,  "CreateWWP_Form" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 42 ,  "CreateWWP_DiscussionMessageMention" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 43 ,  "CreateWWP_DiscussionMessage" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 44 ,  "CreateWWP_MailAttachments" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 45 ,  "CreateWWP_Mail" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 46 ,  "CreateWWP_MailTemplate" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 47 ,  "CreateWWP_Notification" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 48 ,  "CreateWWP_NotificationDefinition" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 49 ,  "CreateWWP_WebClient" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 50 ,  "CreateWWP_WebNotification" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 51 ,  "CreateWWP_SMS" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 52 ,  "CreateWWP_Subscription" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 53 ,  "CreateWWP_Entity" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 54 ,  "CreateWWP_Parameter" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 55 ,  "CreateWWP_UserExtended" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 56 ,  "CreateTrn_MedicalIndication" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 57 ,  "CreateTrn_ResidentType" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 58 ,  "CreateTrn_NetworkCompany" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 59 ,  "CreateTrn_NetworkIndividual" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 60 ,  "CreateTrn_SupplierAGB" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 61 ,  "CreateTrn_SupplierGen" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 62 ,  "CreateTrn_Location" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 63 ,  "CreateTrn_Manager" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 64 ,  "CreateTrn_OrganisationType" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 65 ,  "CreateTrn_Organisation" , new Object[]{ });
      }

      private void ExecuteOnlyRisReorganization( )
      {
         ReorgExecute.RegisterBlockForSubmit( 66 ,  "RITrn_OrganisationTrn_OrganisationType" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 67 ,  "RITrn_ManagerTrn_Organisation" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 68 ,  "RITrn_LocationTrn_Receptionist" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 69 ,  "RITrn_LocationTrn_Theme" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 70 ,  "RITrn_LocationTrn_AppVersion" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 71 ,  "RITrn_LocationTrn_AppVersion1" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 72 ,  "RITrn_SupplierGenTrn_SupplierGenType" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 73 ,  "RITrn_SupplierGenTrn_Location" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 74 ,  "RITrn_SupplierGenTrn_Organisation" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 75 ,  "RITrn_SupplierAGBTrn_SupplierAgbType" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 76 ,  "RIWWP_SubscriptionWWP_NotificationDefinition" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 77 ,  "RIWWP_SubscriptionWWP_UserExtended" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 78 ,  "RIWWP_SMSWWP_Notification" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 79 ,  "RIWWP_WebNotificationWWP_Notification" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 80 ,  "RIWWP_WebClientWWP_UserExtended" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 81 ,  "RIWWP_NotificationDefinitionWWP_Entity" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 82 ,  "RIWWP_NotificationWWP_NotificationDefinition" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 83 ,  "RIWWP_NotificationWWP_UserExtended" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 84 ,  "RIWWP_MailWWP_Notification" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 85 ,  "RIWWP_MailAttachmentsWWP_Mail" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 86 ,  "RIWWP_DiscussionMessageWWP_UserExtended" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 87 ,  "RIWWP_DiscussionMessageWWP_Entity" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 88 ,  "RIWWP_DiscussionMessageWWP_DiscussionMessage" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 89 ,  "RIWWP_DiscussionMessageMentionWWP_DiscussionMessage" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 90 ,  "RIWWP_DiscussionMessageMentionWWP_UserExtended" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 91 ,  "RIWWP_FormElementWWP_FormElement" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 92 ,  "RIWWP_FormInstanceWWP_Form" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 93 ,  "RIWWP_FormInstanceWWP_UserExtended" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 94 ,  "RIWWP_FormInstanceElementWWP_FormInstance" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 95 ,  "RITrn_AgendaCalendarTrn_Location" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 96 ,  "RITrn_ThemeColorTrn_Theme" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 97 ,  "RITrn_ReceptionistTrn_Location" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 98 ,  "RITrn_ResidentTrn_Location" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 99 ,  "RITrn_ResidentTrn_ResidentType" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 100 ,  "RITrn_ResidentTrn_MedicalIndication" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 101 ,  "RITrn_ResidentTrn_ResidentPackage" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 102 ,  "RITrn_ProductServiceTrn_Location" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 103 ,  "RITrn_ProductServiceTrn_SupplierGen" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 104 ,  "RITrn_ProductServiceTrn_SupplierAGB" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 105 ,  "RITrn_LocationDynamicFormTrn_Location" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 106 ,  "RITrn_LocationDynamicFormWWP_Form" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 107 ,  "RITrn_CallToActionTrn_ProductService" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 108 ,  "RITrn_CallToActionTrn_LocationDynamicForm" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 109 ,  "RITrn_AuditTrn_Organisation" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 110 ,  "RITrn_ThemeIconTrn_Theme" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 111 ,  "RITrn_AgendaEventGroupTrn_AgendaCalendar" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 112 ,  "RITrn_ResidentNotificationTrn_AppNotification" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 113 ,  "RITrn_PageTrn_Location" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 114 ,  "RITrn_PageTrn_ProductService" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 115 ,  "RITrn_OrganisationDynamicFormTrn_Organisation" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 116 ,  "RITrn_OrganisationDynamicFormWWP_Form" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 117 ,  "RITrn_OrganisationSettingTrn_Organisation" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 118 ,  "RITrn_OrganisationSettingTrn_Theme" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 119 ,  "RITrn_AppVersionTrn_Location" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 120 ,  "RITrn_AppVersionTrn_Theme" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 121 ,  "RITrn_AppVersionPageTrn_AppVersion" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 122 ,  "RITrn_ResidentPackageTrn_Location" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 123 ,  "RITrn_ThemeCtaColorTrn_Theme" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 124 ,  "RITrn_MemoTrn_Resident" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 125 ,  "RITrn_SupplierDynamicFormTrn_SupplierGen" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 126 ,  "RITrn_SupplierDynamicFormWWP_Form" , new Object[]{ });
      }

      private void ExecuteTablesReorganization( )
      {
         ExecuteOnlyTablesReorganization( ) ;
         ExecuteOnlyRisReorganization( ) ;
         ReorgExecute.SubmitAll() ;
      }

      private void SetPrecedence( )
      {
         SetPrecedencetables( ) ;
         SetPrecedenceris( ) ;
      }

      private void SetPrecedencetables( )
      {
         GXReorganization.SetMsg( 1 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Trn_EnvironmentVariable", ""}) );
         GXReorganization.SetMsg( 2 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Trn_SupplierDynamicForm", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateTrn_SupplierDynamicForm" ,  "CreateTrn_SupplierGen" );
         ReorgExecute.RegisterPrecedence( "CreateTrn_SupplierDynamicForm" ,  "CreateWWP_Form" );
         GXReorganization.SetMsg( 3 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Trn_LocationImage", ""}) );
         GXReorganization.SetMsg( 4 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Trn_ServiceImage", ""}) );
         GXReorganization.SetMsg( 5 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Trn_DiscussionTranslation", ""}) );
         GXReorganization.SetMsg( 6 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Trn_DynamicFormTranslation", ""}) );
         GXReorganization.SetMsg( 7 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Trn_DynamicTranslation", ""}) );
         GXReorganization.SetMsg( 8 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Trn_Memo", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateTrn_Memo" ,  "CreateTrn_Resident" );
         GXReorganization.SetMsg( 9 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Trn_MemoCategory", ""}) );
         GXReorganization.SetMsg( 10 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Trn_ThemeCtaColor", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateTrn_ThemeCtaColor" ,  "CreateTrn_Theme" );
         GXReorganization.SetMsg( 11 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Trn_ResidentPackage", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateTrn_ResidentPackage" ,  "CreateTrn_Location" );
         GXReorganization.SetMsg( 12 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Trn_AppVersionPage", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateTrn_AppVersionPage" ,  "CreateTrn_AppVersion" );
         GXReorganization.SetMsg( 13 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Trn_AppVersion", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateTrn_AppVersion" ,  "CreateTrn_Location" );
         ReorgExecute.RegisterPrecedence( "CreateTrn_AppVersion" ,  "CreateTrn_Theme" );
         GXReorganization.SetMsg( 14 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Trn_OrganisationSetting", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateTrn_OrganisationSetting" ,  "CreateTrn_Organisation" );
         ReorgExecute.RegisterPrecedence( "CreateTrn_OrganisationSetting" ,  "CreateTrn_Theme" );
         GXReorganization.SetMsg( 15 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Trn_OrganisationDynamicForm", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateTrn_OrganisationDynamicForm" ,  "CreateTrn_Organisation" );
         ReorgExecute.RegisterPrecedence( "CreateTrn_OrganisationDynamicForm" ,  "CreateWWP_Form" );
         GXReorganization.SetMsg( 16 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Trn_Page", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateTrn_Page" ,  "CreateTrn_Location" );
         ReorgExecute.RegisterPrecedence( "CreateTrn_Page" ,  "CreateTrn_ProductService" );
         GXReorganization.SetMsg( 17 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Trn_ResidentNotification", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateTrn_ResidentNotification" ,  "CreateTrn_AppNotification" );
         GXReorganization.SetMsg( 18 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Trn_AppNotification", ""}) );
         GXReorganization.SetMsg( 19 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Trn_AgendaEventGroup", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateTrn_AgendaEventGroup" ,  "CreateTrn_AgendaCalendar" );
         GXReorganization.SetMsg( 20 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Trn_ThemeIcon", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateTrn_ThemeIcon" ,  "CreateTrn_Theme" );
         GXReorganization.SetMsg( 21 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Trn_Media", ""}) );
         GXReorganization.SetMsg( 22 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Trn_PreferredGenSupplier", ""}) );
         GXReorganization.SetMsg( 23 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Trn_PreferredAgbSupplier", ""}) );
         GXReorganization.SetMsg( 24 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Trn_Audit", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateTrn_Audit" ,  "CreateTrn_Organisation" );
         GXReorganization.SetMsg( 25 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Trn_CallToAction", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateTrn_CallToAction" ,  "CreateTrn_ProductService" );
         ReorgExecute.RegisterPrecedence( "CreateTrn_CallToAction" ,  "CreateTrn_LocationDynamicForm" );
         GXReorganization.SetMsg( 26 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Trn_LocationDynamicForm", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateTrn_LocationDynamicForm" ,  "CreateTrn_Location" );
         ReorgExecute.RegisterPrecedence( "CreateTrn_LocationDynamicForm" ,  "CreateWWP_Form" );
         GXReorganization.SetMsg( 27 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Trn_ProductService", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateTrn_ProductService" ,  "CreateTrn_Location" );
         ReorgExecute.RegisterPrecedence( "CreateTrn_ProductService" ,  "CreateTrn_SupplierGen" );
         ReorgExecute.RegisterPrecedence( "CreateTrn_ProductService" ,  "CreateTrn_SupplierAGB" );
         GXReorganization.SetMsg( 28 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Trn_Device", ""}) );
         GXReorganization.SetMsg( 29 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Trn_Resident", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateTrn_Resident" ,  "CreateTrn_Location" );
         ReorgExecute.RegisterPrecedence( "CreateTrn_Resident" ,  "CreateTrn_ResidentType" );
         ReorgExecute.RegisterPrecedence( "CreateTrn_Resident" ,  "CreateTrn_MedicalIndication" );
         ReorgExecute.RegisterPrecedence( "CreateTrn_Resident" ,  "CreateTrn_ResidentPackage" );
         GXReorganization.SetMsg( 30 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Trn_Receptionist", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateTrn_Receptionist" ,  "CreateTrn_Location" );
         GXReorganization.SetMsg( 31 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Trn_Template", ""}) );
         GXReorganization.SetMsg( 32 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Trn_ThemeColor", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateTrn_ThemeColor" ,  "CreateTrn_Theme" );
         GXReorganization.SetMsg( 33 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Trn_Theme", ""}) );
         GXReorganization.SetMsg( 34 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Trn_AgendaCalendar", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateTrn_AgendaCalendar" ,  "CreateTrn_Location" );
         GXReorganization.SetMsg( 35 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Trn_SupplierGenType", ""}) );
         GXReorganization.SetMsg( 36 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Trn_SupplierAgbType", ""}) );
         GXReorganization.SetMsg( 37 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"UserCustomizations", ""}) );
         GXReorganization.SetMsg( 38 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"WWP_FormInstanceElement", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateWWP_FormInstanceElement" ,  "CreateWWP_FormInstance" );
         GXReorganization.SetMsg( 39 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"WWP_FormInstance", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateWWP_FormInstance" ,  "CreateWWP_Form" );
         ReorgExecute.RegisterPrecedence( "CreateWWP_FormInstance" ,  "CreateWWP_UserExtended" );
         GXReorganization.SetMsg( 40 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"WWP_FormElement", ""}) );
         GXReorganization.SetMsg( 41 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"WWP_Form", ""}) );
         GXReorganization.SetMsg( 42 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"WWP_DiscussionMessageMention", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateWWP_DiscussionMessageMention" ,  "CreateWWP_DiscussionMessage" );
         ReorgExecute.RegisterPrecedence( "CreateWWP_DiscussionMessageMention" ,  "CreateWWP_UserExtended" );
         GXReorganization.SetMsg( 43 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"WWP_DiscussionMessage", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateWWP_DiscussionMessage" ,  "CreateWWP_UserExtended" );
         ReorgExecute.RegisterPrecedence( "CreateWWP_DiscussionMessage" ,  "CreateWWP_Entity" );
         GXReorganization.SetMsg( 44 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"WWP_MailAttachments", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateWWP_MailAttachments" ,  "CreateWWP_Mail" );
         GXReorganization.SetMsg( 45 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"WWP_Mail", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateWWP_Mail" ,  "CreateWWP_Notification" );
         GXReorganization.SetMsg( 46 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"WWP_MailTemplate", ""}) );
         GXReorganization.SetMsg( 47 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"WWP_Notification", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateWWP_Notification" ,  "CreateWWP_NotificationDefinition" );
         ReorgExecute.RegisterPrecedence( "CreateWWP_Notification" ,  "CreateWWP_UserExtended" );
         GXReorganization.SetMsg( 48 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"WWP_NotificationDefinition", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateWWP_NotificationDefinition" ,  "CreateWWP_Entity" );
         GXReorganization.SetMsg( 49 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"WWP_WebClient", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateWWP_WebClient" ,  "CreateWWP_UserExtended" );
         GXReorganization.SetMsg( 50 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"WWP_WebNotification", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateWWP_WebNotification" ,  "CreateWWP_Notification" );
         GXReorganization.SetMsg( 51 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"WWP_SMS", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateWWP_SMS" ,  "CreateWWP_Notification" );
         GXReorganization.SetMsg( 52 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"WWP_Subscription", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateWWP_Subscription" ,  "CreateWWP_NotificationDefinition" );
         ReorgExecute.RegisterPrecedence( "CreateWWP_Subscription" ,  "CreateWWP_UserExtended" );
         GXReorganization.SetMsg( 53 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"WWP_Entity", ""}) );
         GXReorganization.SetMsg( 54 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"WWP_Parameter", ""}) );
         GXReorganization.SetMsg( 55 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"WWP_UserExtended", ""}) );
         GXReorganization.SetMsg( 56 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Trn_MedicalIndication", ""}) );
         GXReorganization.SetMsg( 57 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Trn_ResidentType", ""}) );
         GXReorganization.SetMsg( 58 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Trn_NetworkCompany", ""}) );
         GXReorganization.SetMsg( 59 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Trn_NetworkIndividual", ""}) );
         GXReorganization.SetMsg( 60 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Trn_SupplierAGB", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateTrn_SupplierAGB" ,  "CreateTrn_SupplierAgbType" );
         GXReorganization.SetMsg( 61 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Trn_SupplierGen", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateTrn_SupplierGen" ,  "CreateTrn_SupplierGenType" );
         ReorgExecute.RegisterPrecedence( "CreateTrn_SupplierGen" ,  "CreateTrn_Location" );
         ReorgExecute.RegisterPrecedence( "CreateTrn_SupplierGen" ,  "CreateTrn_Organisation" );
         GXReorganization.SetMsg( 62 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Trn_Location", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateTrn_Location" ,  "CreateTrn_Theme" );
         GXReorganization.SetMsg( 63 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Trn_Manager", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateTrn_Manager" ,  "CreateTrn_Organisation" );
         GXReorganization.SetMsg( 64 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Trn_OrganisationType", ""}) );
         GXReorganization.SetMsg( 65 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Trn_Organisation", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateTrn_Organisation" ,  "CreateTrn_OrganisationType" );
      }

      private void SetPrecedenceris( )
      {
         GXReorganization.SetMsg( 66 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ITRN_ORGANISATION1"}) );
         ReorgExecute.RegisterPrecedence( "RITrn_OrganisationTrn_OrganisationType" ,  "CreateTrn_Organisation" );
         ReorgExecute.RegisterPrecedence( "RITrn_OrganisationTrn_OrganisationType" ,  "CreateTrn_OrganisationType" );
         GXReorganization.SetMsg( 67 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ITRN_MANAGER1"}) );
         ReorgExecute.RegisterPrecedence( "RITrn_ManagerTrn_Organisation" ,  "CreateTrn_Manager" );
         ReorgExecute.RegisterPrecedence( "RITrn_ManagerTrn_Organisation" ,  "CreateTrn_Organisation" );
         GXReorganization.SetMsg( 68 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ITRN_LOCATION1"}) );
         ReorgExecute.RegisterPrecedence( "RITrn_LocationTrn_Receptionist" ,  "CreateTrn_Location" );
         ReorgExecute.RegisterPrecedence( "RITrn_LocationTrn_Receptionist" ,  "CreateTrn_Receptionist" );
         GXReorganization.SetMsg( 69 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ITRN_LOCATION3"}) );
         ReorgExecute.RegisterPrecedence( "RITrn_LocationTrn_Theme" ,  "CreateTrn_Location" );
         ReorgExecute.RegisterPrecedence( "RITrn_LocationTrn_Theme" ,  "CreateTrn_Theme" );
         GXReorganization.SetMsg( 70 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ITRN_LOCATION5"}) );
         ReorgExecute.RegisterPrecedence( "RITrn_LocationTrn_AppVersion" ,  "CreateTrn_Location" );
         ReorgExecute.RegisterPrecedence( "RITrn_LocationTrn_AppVersion" ,  "CreateTrn_AppVersion" );
         GXReorganization.SetMsg( 71 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ITRN_LOCATION4"}) );
         ReorgExecute.RegisterPrecedence( "RITrn_LocationTrn_AppVersion1" ,  "CreateTrn_Location" );
         ReorgExecute.RegisterPrecedence( "RITrn_LocationTrn_AppVersion1" ,  "CreateTrn_AppVersion" );
         GXReorganization.SetMsg( 72 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ITRN_SUPPLIERGEN1"}) );
         ReorgExecute.RegisterPrecedence( "RITrn_SupplierGenTrn_SupplierGenType" ,  "CreateTrn_SupplierGen" );
         ReorgExecute.RegisterPrecedence( "RITrn_SupplierGenTrn_SupplierGenType" ,  "CreateTrn_SupplierGenType" );
         GXReorganization.SetMsg( 73 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ITRN_SUPPLIERGEN3"}) );
         ReorgExecute.RegisterPrecedence( "RITrn_SupplierGenTrn_Location" ,  "CreateTrn_SupplierGen" );
         ReorgExecute.RegisterPrecedence( "RITrn_SupplierGenTrn_Location" ,  "CreateTrn_Location" );
         GXReorganization.SetMsg( 74 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ITRN_SUPPLIERGEN2"}) );
         ReorgExecute.RegisterPrecedence( "RITrn_SupplierGenTrn_Organisation" ,  "CreateTrn_SupplierGen" );
         ReorgExecute.RegisterPrecedence( "RITrn_SupplierGenTrn_Organisation" ,  "CreateTrn_Organisation" );
         GXReorganization.SetMsg( 75 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ITRN_SUPPLIERAGB1"}) );
         ReorgExecute.RegisterPrecedence( "RITrn_SupplierAGBTrn_SupplierAgbType" ,  "CreateTrn_SupplierAGB" );
         ReorgExecute.RegisterPrecedence( "RITrn_SupplierAGBTrn_SupplierAgbType" ,  "CreateTrn_SupplierAgbType" );
         GXReorganization.SetMsg( 76 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IWWP_SUBSCRIPTION2"}) );
         ReorgExecute.RegisterPrecedence( "RIWWP_SubscriptionWWP_NotificationDefinition" ,  "CreateWWP_Subscription" );
         ReorgExecute.RegisterPrecedence( "RIWWP_SubscriptionWWP_NotificationDefinition" ,  "CreateWWP_NotificationDefinition" );
         GXReorganization.SetMsg( 77 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IWWP_SUBSCRIPTION1"}) );
         ReorgExecute.RegisterPrecedence( "RIWWP_SubscriptionWWP_UserExtended" ,  "CreateWWP_Subscription" );
         ReorgExecute.RegisterPrecedence( "RIWWP_SubscriptionWWP_UserExtended" ,  "CreateWWP_UserExtended" );
         GXReorganization.SetMsg( 78 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IWWP_SMS1"}) );
         ReorgExecute.RegisterPrecedence( "RIWWP_SMSWWP_Notification" ,  "CreateWWP_SMS" );
         ReorgExecute.RegisterPrecedence( "RIWWP_SMSWWP_Notification" ,  "CreateWWP_Notification" );
         GXReorganization.SetMsg( 79 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IWWP_WEBNOTIFICATION1"}) );
         ReorgExecute.RegisterPrecedence( "RIWWP_WebNotificationWWP_Notification" ,  "CreateWWP_WebNotification" );
         ReorgExecute.RegisterPrecedence( "RIWWP_WebNotificationWWP_Notification" ,  "CreateWWP_Notification" );
         GXReorganization.SetMsg( 80 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IWWP_WEBCLIENT1"}) );
         ReorgExecute.RegisterPrecedence( "RIWWP_WebClientWWP_UserExtended" ,  "CreateWWP_WebClient" );
         ReorgExecute.RegisterPrecedence( "RIWWP_WebClientWWP_UserExtended" ,  "CreateWWP_UserExtended" );
         GXReorganization.SetMsg( 81 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IWWP_NOTIFICATIONDEFINITION1"}) );
         ReorgExecute.RegisterPrecedence( "RIWWP_NotificationDefinitionWWP_Entity" ,  "CreateWWP_NotificationDefinition" );
         ReorgExecute.RegisterPrecedence( "RIWWP_NotificationDefinitionWWP_Entity" ,  "CreateWWP_Entity" );
         GXReorganization.SetMsg( 82 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IWWP_NOTIFICATION2"}) );
         ReorgExecute.RegisterPrecedence( "RIWWP_NotificationWWP_NotificationDefinition" ,  "CreateWWP_Notification" );
         ReorgExecute.RegisterPrecedence( "RIWWP_NotificationWWP_NotificationDefinition" ,  "CreateWWP_NotificationDefinition" );
         GXReorganization.SetMsg( 83 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IWWP_NOTIFICATION1"}) );
         ReorgExecute.RegisterPrecedence( "RIWWP_NotificationWWP_UserExtended" ,  "CreateWWP_Notification" );
         ReorgExecute.RegisterPrecedence( "RIWWP_NotificationWWP_UserExtended" ,  "CreateWWP_UserExtended" );
         GXReorganization.SetMsg( 84 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IWWP_MAIL1"}) );
         ReorgExecute.RegisterPrecedence( "RIWWP_MailWWP_Notification" ,  "CreateWWP_Mail" );
         ReorgExecute.RegisterPrecedence( "RIWWP_MailWWP_Notification" ,  "CreateWWP_Notification" );
         GXReorganization.SetMsg( 85 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IWWP_MAILATTACHMENTS1"}) );
         ReorgExecute.RegisterPrecedence( "RIWWP_MailAttachmentsWWP_Mail" ,  "CreateWWP_MailAttachments" );
         ReorgExecute.RegisterPrecedence( "RIWWP_MailAttachmentsWWP_Mail" ,  "CreateWWP_Mail" );
         GXReorganization.SetMsg( 86 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IWWP_DISCUSSIONMESSAGE3"}) );
         ReorgExecute.RegisterPrecedence( "RIWWP_DiscussionMessageWWP_UserExtended" ,  "CreateWWP_DiscussionMessage" );
         ReorgExecute.RegisterPrecedence( "RIWWP_DiscussionMessageWWP_UserExtended" ,  "CreateWWP_UserExtended" );
         GXReorganization.SetMsg( 87 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IWWP_DISCUSSIONMESSAGE2"}) );
         ReorgExecute.RegisterPrecedence( "RIWWP_DiscussionMessageWWP_Entity" ,  "CreateWWP_DiscussionMessage" );
         ReorgExecute.RegisterPrecedence( "RIWWP_DiscussionMessageWWP_Entity" ,  "CreateWWP_Entity" );
         GXReorganization.SetMsg( 88 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IWWP_DISCUSSIONMESSAGE1"}) );
         ReorgExecute.RegisterPrecedence( "RIWWP_DiscussionMessageWWP_DiscussionMessage" ,  "CreateWWP_DiscussionMessage" );
         ReorgExecute.RegisterPrecedence( "RIWWP_DiscussionMessageWWP_DiscussionMessage" ,  "CreateWWP_DiscussionMessage" );
         GXReorganization.SetMsg( 89 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IWWP_DISCUSSIONMESSAGEMENTION2"}) );
         ReorgExecute.RegisterPrecedence( "RIWWP_DiscussionMessageMentionWWP_DiscussionMessage" ,  "CreateWWP_DiscussionMessageMention" );
         ReorgExecute.RegisterPrecedence( "RIWWP_DiscussionMessageMentionWWP_DiscussionMessage" ,  "CreateWWP_DiscussionMessage" );
         GXReorganization.SetMsg( 90 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IWWP_DISCUSSIONMESSAGEMENTION1"}) );
         ReorgExecute.RegisterPrecedence( "RIWWP_DiscussionMessageMentionWWP_UserExtended" ,  "CreateWWP_DiscussionMessageMention" );
         ReorgExecute.RegisterPrecedence( "RIWWP_DiscussionMessageMentionWWP_UserExtended" ,  "CreateWWP_UserExtended" );
         GXReorganization.SetMsg( 91 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IWWPFORMELEMENT1"}) );
         ReorgExecute.RegisterPrecedence( "RIWWP_FormElementWWP_FormElement" ,  "CreateWWP_FormElement" );
         ReorgExecute.RegisterPrecedence( "RIWWP_FormElementWWP_FormElement" ,  "CreateWWP_FormElement" );
         GXReorganization.SetMsg( 92 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IWWPFORMINSTANCE1"}) );
         ReorgExecute.RegisterPrecedence( "RIWWP_FormInstanceWWP_Form" ,  "CreateWWP_FormInstance" );
         ReorgExecute.RegisterPrecedence( "RIWWP_FormInstanceWWP_Form" ,  "CreateWWP_Form" );
         GXReorganization.SetMsg( 93 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IWWP_FORMINSTANCE"}) );
         ReorgExecute.RegisterPrecedence( "RIWWP_FormInstanceWWP_UserExtended" ,  "CreateWWP_FormInstance" );
         ReorgExecute.RegisterPrecedence( "RIWWP_FormInstanceWWP_UserExtended" ,  "CreateWWP_UserExtended" );
         GXReorganization.SetMsg( 94 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IWWPFORMINSTANCEELEMENT1"}) );
         ReorgExecute.RegisterPrecedence( "RIWWP_FormInstanceElementWWP_FormInstance" ,  "CreateWWP_FormInstanceElement" );
         ReorgExecute.RegisterPrecedence( "RIWWP_FormInstanceElementWWP_FormInstance" ,  "CreateWWP_FormInstance" );
         GXReorganization.SetMsg( 95 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ITRN_AGENDACALENDAR1"}) );
         ReorgExecute.RegisterPrecedence( "RITrn_AgendaCalendarTrn_Location" ,  "CreateTrn_AgendaCalendar" );
         ReorgExecute.RegisterPrecedence( "RITrn_AgendaCalendarTrn_Location" ,  "CreateTrn_Location" );
         GXReorganization.SetMsg( 96 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ITRN_THEMECOLOR1"}) );
         ReorgExecute.RegisterPrecedence( "RITrn_ThemeColorTrn_Theme" ,  "CreateTrn_ThemeColor" );
         ReorgExecute.RegisterPrecedence( "RITrn_ThemeColorTrn_Theme" ,  "CreateTrn_Theme" );
         GXReorganization.SetMsg( 97 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ITRN_RECEPTIONIST1"}) );
         ReorgExecute.RegisterPrecedence( "RITrn_ReceptionistTrn_Location" ,  "CreateTrn_Receptionist" );
         ReorgExecute.RegisterPrecedence( "RITrn_ReceptionistTrn_Location" ,  "CreateTrn_Location" );
         GXReorganization.SetMsg( 98 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ITRN_RESIDENT4"}) );
         ReorgExecute.RegisterPrecedence( "RITrn_ResidentTrn_Location" ,  "CreateTrn_Resident" );
         ReorgExecute.RegisterPrecedence( "RITrn_ResidentTrn_Location" ,  "CreateTrn_Location" );
         GXReorganization.SetMsg( 99 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ITRN_RESIDENT3"}) );
         ReorgExecute.RegisterPrecedence( "RITrn_ResidentTrn_ResidentType" ,  "CreateTrn_Resident" );
         ReorgExecute.RegisterPrecedence( "RITrn_ResidentTrn_ResidentType" ,  "CreateTrn_ResidentType" );
         GXReorganization.SetMsg( 100 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ITRN_RESIDENT2"}) );
         ReorgExecute.RegisterPrecedence( "RITrn_ResidentTrn_MedicalIndication" ,  "CreateTrn_Resident" );
         ReorgExecute.RegisterPrecedence( "RITrn_ResidentTrn_MedicalIndication" ,  "CreateTrn_MedicalIndication" );
         GXReorganization.SetMsg( 101 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ITRN_RESIDENT1"}) );
         ReorgExecute.RegisterPrecedence( "RITrn_ResidentTrn_ResidentPackage" ,  "CreateTrn_Resident" );
         ReorgExecute.RegisterPrecedence( "RITrn_ResidentTrn_ResidentPackage" ,  "CreateTrn_ResidentPackage" );
         GXReorganization.SetMsg( 102 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ITRN_PRODUCTSERVICE3"}) );
         ReorgExecute.RegisterPrecedence( "RITrn_ProductServiceTrn_Location" ,  "CreateTrn_ProductService" );
         ReorgExecute.RegisterPrecedence( "RITrn_ProductServiceTrn_Location" ,  "CreateTrn_Location" );
         GXReorganization.SetMsg( 103 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ITRN_PRODUCTSERVICE2"}) );
         ReorgExecute.RegisterPrecedence( "RITrn_ProductServiceTrn_SupplierGen" ,  "CreateTrn_ProductService" );
         ReorgExecute.RegisterPrecedence( "RITrn_ProductServiceTrn_SupplierGen" ,  "CreateTrn_SupplierGen" );
         GXReorganization.SetMsg( 104 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ITRN_PRODUCTSERVICE1"}) );
         ReorgExecute.RegisterPrecedence( "RITrn_ProductServiceTrn_SupplierAGB" ,  "CreateTrn_ProductService" );
         ReorgExecute.RegisterPrecedence( "RITrn_ProductServiceTrn_SupplierAGB" ,  "CreateTrn_SupplierAGB" );
         GXReorganization.SetMsg( 105 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ITRN_LOCATIONDYNAMICFORM2"}) );
         ReorgExecute.RegisterPrecedence( "RITrn_LocationDynamicFormTrn_Location" ,  "CreateTrn_LocationDynamicForm" );
         ReorgExecute.RegisterPrecedence( "RITrn_LocationDynamicFormTrn_Location" ,  "CreateTrn_Location" );
         GXReorganization.SetMsg( 106 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ITRN_LOCATIONDYNAMICFORM1"}) );
         ReorgExecute.RegisterPrecedence( "RITrn_LocationDynamicFormWWP_Form" ,  "CreateTrn_LocationDynamicForm" );
         ReorgExecute.RegisterPrecedence( "RITrn_LocationDynamicFormWWP_Form" ,  "CreateWWP_Form" );
         GXReorganization.SetMsg( 107 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ITRN_CALLTOACTION2"}) );
         ReorgExecute.RegisterPrecedence( "RITrn_CallToActionTrn_ProductService" ,  "CreateTrn_CallToAction" );
         ReorgExecute.RegisterPrecedence( "RITrn_CallToActionTrn_ProductService" ,  "CreateTrn_ProductService" );
         GXReorganization.SetMsg( 108 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ITRN_CALLTOACTION1"}) );
         ReorgExecute.RegisterPrecedence( "RITrn_CallToActionTrn_LocationDynamicForm" ,  "CreateTrn_CallToAction" );
         ReorgExecute.RegisterPrecedence( "RITrn_CallToActionTrn_LocationDynamicForm" ,  "CreateTrn_LocationDynamicForm" );
         GXReorganization.SetMsg( 109 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ITRN_AUDIT"}) );
         ReorgExecute.RegisterPrecedence( "RITrn_AuditTrn_Organisation" ,  "CreateTrn_Audit" );
         ReorgExecute.RegisterPrecedence( "RITrn_AuditTrn_Organisation" ,  "CreateTrn_Organisation" );
         GXReorganization.SetMsg( 110 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ITRN_THEMEICON1"}) );
         ReorgExecute.RegisterPrecedence( "RITrn_ThemeIconTrn_Theme" ,  "CreateTrn_ThemeIcon" );
         ReorgExecute.RegisterPrecedence( "RITrn_ThemeIconTrn_Theme" ,  "CreateTrn_Theme" );
         GXReorganization.SetMsg( 111 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ITRN_AGENDAEVENTGROUP1"}) );
         ReorgExecute.RegisterPrecedence( "RITrn_AgendaEventGroupTrn_AgendaCalendar" ,  "CreateTrn_AgendaEventGroup" );
         ReorgExecute.RegisterPrecedence( "RITrn_AgendaEventGroupTrn_AgendaCalendar" ,  "CreateTrn_AgendaCalendar" );
         GXReorganization.SetMsg( 112 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ITRN_RESIDENTNOTIFICATION1"}) );
         ReorgExecute.RegisterPrecedence( "RITrn_ResidentNotificationTrn_AppNotification" ,  "CreateTrn_ResidentNotification" );
         ReorgExecute.RegisterPrecedence( "RITrn_ResidentNotificationTrn_AppNotification" ,  "CreateTrn_AppNotification" );
         GXReorganization.SetMsg( 113 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"GX_002G000B000T"}) );
         ReorgExecute.RegisterPrecedence( "RITrn_PageTrn_Location" ,  "CreateTrn_Page" );
         ReorgExecute.RegisterPrecedence( "RITrn_PageTrn_Location" ,  "CreateTrn_Location" );
         GXReorganization.SetMsg( 114 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ITRN_PAGE1"}) );
         ReorgExecute.RegisterPrecedence( "RITrn_PageTrn_ProductService" ,  "CreateTrn_Page" );
         ReorgExecute.RegisterPrecedence( "RITrn_PageTrn_ProductService" ,  "CreateTrn_ProductService" );
         GXReorganization.SetMsg( 115 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ITRN_ORGANISATIONDYNAMICFORM2"}) );
         ReorgExecute.RegisterPrecedence( "RITrn_OrganisationDynamicFormTrn_Organisation" ,  "CreateTrn_OrganisationDynamicForm" );
         ReorgExecute.RegisterPrecedence( "RITrn_OrganisationDynamicFormTrn_Organisation" ,  "CreateTrn_Organisation" );
         GXReorganization.SetMsg( 116 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ITRN_ORGANISATIONDYNAMICFORM1"}) );
         ReorgExecute.RegisterPrecedence( "RITrn_OrganisationDynamicFormWWP_Form" ,  "CreateTrn_OrganisationDynamicForm" );
         ReorgExecute.RegisterPrecedence( "RITrn_OrganisationDynamicFormWWP_Form" ,  "CreateWWP_Form" );
         GXReorganization.SetMsg( 117 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ITRN_ORGANISATIONSETTING1"}) );
         ReorgExecute.RegisterPrecedence( "RITrn_OrganisationSettingTrn_Organisation" ,  "CreateTrn_OrganisationSetting" );
         ReorgExecute.RegisterPrecedence( "RITrn_OrganisationSettingTrn_Organisation" ,  "CreateTrn_Organisation" );
         GXReorganization.SetMsg( 118 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ITRN_ORGANISATIONSETTING2"}) );
         ReorgExecute.RegisterPrecedence( "RITrn_OrganisationSettingTrn_Theme" ,  "CreateTrn_OrganisationSetting" );
         ReorgExecute.RegisterPrecedence( "RITrn_OrganisationSettingTrn_Theme" ,  "CreateTrn_Theme" );
         GXReorganization.SetMsg( 119 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ITRN_APPVERSION1"}) );
         ReorgExecute.RegisterPrecedence( "RITrn_AppVersionTrn_Location" ,  "CreateTrn_AppVersion" );
         ReorgExecute.RegisterPrecedence( "RITrn_AppVersionTrn_Location" ,  "CreateTrn_Location" );
         GXReorganization.SetMsg( 120 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ITRN_APPVERSION2"}) );
         ReorgExecute.RegisterPrecedence( "RITrn_AppVersionTrn_Theme" ,  "CreateTrn_AppVersion" );
         ReorgExecute.RegisterPrecedence( "RITrn_AppVersionTrn_Theme" ,  "CreateTrn_Theme" );
         GXReorganization.SetMsg( 121 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ITRN_APPVERSIONPAGE2"}) );
         ReorgExecute.RegisterPrecedence( "RITrn_AppVersionPageTrn_AppVersion" ,  "CreateTrn_AppVersionPage" );
         ReorgExecute.RegisterPrecedence( "RITrn_AppVersionPageTrn_AppVersion" ,  "CreateTrn_AppVersion" );
         GXReorganization.SetMsg( 122 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ITRN_RESIDENTPACKAGE1"}) );
         ReorgExecute.RegisterPrecedence( "RITrn_ResidentPackageTrn_Location" ,  "CreateTrn_ResidentPackage" );
         ReorgExecute.RegisterPrecedence( "RITrn_ResidentPackageTrn_Location" ,  "CreateTrn_Location" );
         GXReorganization.SetMsg( 123 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ITRN_THEMECTACOLOR1"}) );
         ReorgExecute.RegisterPrecedence( "RITrn_ThemeCtaColorTrn_Theme" ,  "CreateTrn_ThemeCtaColor" );
         ReorgExecute.RegisterPrecedence( "RITrn_ThemeCtaColorTrn_Theme" ,  "CreateTrn_Theme" );
         GXReorganization.SetMsg( 124 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ITRN_MEMO2"}) );
         ReorgExecute.RegisterPrecedence( "RITrn_MemoTrn_Resident" ,  "CreateTrn_Memo" );
         ReorgExecute.RegisterPrecedence( "RITrn_MemoTrn_Resident" ,  "CreateTrn_Resident" );
         GXReorganization.SetMsg( 125 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ITRN_SUPPLIERDYNAMICFORM2"}) );
         ReorgExecute.RegisterPrecedence( "RITrn_SupplierDynamicFormTrn_SupplierGen" ,  "CreateTrn_SupplierDynamicForm" );
         ReorgExecute.RegisterPrecedence( "RITrn_SupplierDynamicFormTrn_SupplierGen" ,  "CreateTrn_SupplierGen" );
         GXReorganization.SetMsg( 126 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ITRN_SUPPLIERDYNAMICFORM1"}) );
         ReorgExecute.RegisterPrecedence( "RITrn_SupplierDynamicFormWWP_Form" ,  "CreateTrn_SupplierDynamicForm" );
         ReorgExecute.RegisterPrecedence( "RITrn_SupplierDynamicFormWWP_Form" ,  "CreateWWP_Form" );
      }

      private void ExecuteReorganization( )
      {
         if ( ErrCode == 0 )
         {
            TablesCount( ) ;
            if ( ! PrintOnlyRecordCount( ) )
            {
               FirstActions( ) ;
               SetPrecedence( ) ;
               ExecuteTablesReorganization( ) ;
            }
         }
      }

      public void UtilsCleanup( )
      {
         cleanup();
      }

      public override void cleanup( )
      {
         CloseCursors();
      }

      public override void initialize( )
      {
         DS = new GxDataStore();
         ErrMsg = "";
         DataBaseName = "";
         sSchemaVar = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.reorg__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      protected short ErrCode ;
      protected short Count ;
      protected short Res ;
      protected string ErrMsg ;
      protected string DataBaseName ;
      protected string cmdBuffer ;
      protected string sSchemaVar ;
      protected GxDataStore DS ;
      protected IGxDataStore dsDataStore1 ;
      protected IGxDataStore dsGAM ;
      protected IGxDataStore dsDefault ;
      protected GxCommand RGZ ;
      protected IDataStoreProvider pr_default ;
   }

   public class reorg__default : DataStoreHelperBase, IDataStoreHelper
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
