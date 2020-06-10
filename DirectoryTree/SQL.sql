/****** Скрипт Выборки Технических Параметров по материалу  ******/
SELECT TOP (1000) [MaterialsParameters].[Id] AS [Id]
      ,[MaterialsParameters].[IdMaterial] AS [MaterialId]
      ,[MaterialsParameters].[IdParameter] AS [ParameterId]
	  ,[TechnicalParameters].[Name] AS [ParameterName]
      ,[MaterialsParameters].[Value] AS [Value]
      ,[MaterialsParameters].[Unit] AS [Unit]
  FROM [PortalEIPS].[dbo].[MaterialsParameters] as [MaterialsParameters]
  LEFT OUTER JOIN [dbo].[TechnicalParameters] as [TechnicalParameters] ON [TechnicalParameters].[Id] = [MaterialsParameters].[IdParameter]
  Where [IdMaterial] = '159669'
  Order by [TechnicalParameters].[Name]

/****** Скрипт для выборки поставщиков  ******/
SELECT [MaterialsMakers].[Id] As [Id]
      ,[MaterialsMakers].[IdMaterial] As [MaterialId]
	  ,[Subdivisions].[Name] as [Subdivision]
      ,[MaterialsMakers].[Price] as [Price]
      ,[MaterialsMakers].[Currency] as [Currency]
  FROM [PortalEIPS].[dbo].[MaterialsMakers] as [MaterialsMakers]
  LEFT OUTER join [dbo].[Materials] as [Materials] on [Materials].[id] =  [MaterialsMakers].[IdMaterial]
  LEFT OUTER JOIN [dbo].[Subdivisions] as [Subdivisions] on [Subdivisions].[id] =  [MaterialsMakers].[IdMaker]
  Where [MaterialsMakers].[IdMaterial] = '141973'


/****** Скрипт для выборки Материалов ******/
SELECT TOP (1000) [Materials].[Id]
      ,[Materials].[IdClass]
	  ,[MaterialsClasses].[Name] as [MaterialsClassesName]/**/
      ,[Materials].[Stage]
	  ,[Stage].[Description] as [StageValue]
      ,[Materials].[Number]
      ,[Materials].[NumberOZM]
      ,[Materials].[NumberMaker]
      ,[Materials].[Mark]
      ,[Materials].[Name]
      ,[Materials].[Type]
      ,[Materials].[Unit]
      ,[Materials].[Weight]
      ,[Materials].[Currency]
      ,[Materials].[Price]
      ,[Materials].[IdMaker]	  
      ,[Materials].[RequireAlternativeMaker]
      ,[Materials].[NormDoc]
      ,[Materials].[NormDocMaterial]
      ,[Materials].[Info]
      ,[Materials].[Has2DDraw]
      ,[Materials].[Has3DModel]
      ,[Materials].[Stock]
      ,[Materials].[IdUpdater]
	  ,[IdUpdater].[Name] as [IdUpdaterName]/**/
      ,[Materials].[DateOfUpdate]
      ,[Materials].[IdStatus]
	  ,[IdStatus].[Value] as [StatusValue]
      ,[Materials].[IdWorkFlowCurrentNode]
      ,[Materials].[IdDBCreator]
	  ,[IdDBCreator].[Name] as [IdDBCreatorName]/**/
      ,[Materials].[DBDateOfCreate]
      ,[Materials].[IdDBUpdater]
	  ,[IdDBUpdater].[Name] as [IdDBUpdaterName] /**/
      ,[Materials].[DBDateOfUpdate]
      ,[Materials].[DBUpdaterCompName]
      ,[Materials].[DBStatus]
      ,[Materials].[DeleteReason]
      ,[Materials].[IdReplacedMaterial]
      ,[Materials].[SapLoaded]
      ,[Materials].[UsedOnNLMK]
      ,[Materials].[Price_old]
  FROM [PortalEIPS].[dbo].[Materials] as [Materials]
  LEFT OUTER JOIN [dbo].[MaterialsClasses] as [MaterialsClasses] on [MaterialsClasses].id = [Materials].IdClass
  LEFT OUTER JOIN [dbo].[Workers] as [IdDBCreator] on [IdDBCreator].id = [Materials].IdDBCreator
  LEFT OUTER JOIN [dbo].[Workers] as [IdDBUpdater] on [IdDBUpdater].id = [Materials].IdDBUpdater
  LEFT OUTER JOIN [dbo].[Workers] as [IdUpdater] on [IdUpdater].id = [Materials].IdUpdater
  LEFT OUTER JOIN [dbo].[Constants] as [Stage] on [Stage].id = [Materials].Stage
  LEFT OUTER JOIN [dbo].[Constants] as [IdStatus] on [IdStatus].id = [Materials].IdStatus

Where [Materials].[Id] ='68119'