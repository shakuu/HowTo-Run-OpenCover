# [Компонентно тестване примери + Code coverage tool (@TelerikAcademy Unit Testing Forum) ](https://telerikacademy.com/Forum/Questions/197396/%D0%9A%D0%BE%D0%BC%D0%BF%D0%BE%D0%BD%D0%B5%D0%BD%D1%82%D0%BD%D0%BE-%D1%82%D0%B5%D1%81%D1%82%D0%B2%D0%B0%D0%BD%D0%B5-%D0%BF%D1%80%D0%B8%D0%BC%D0%B5%D1%80%D0%B8-Code-coverage-tool)

1. Nuget Packages
   - OpenCover
   - NUnit.Runners
   - ReportGenerator

2. Files
   - tests.bat 
      - <path to Nunit console runner> <tests.dll>
   - report.bat
      - <path to OpenCover> -target:tests.bat -register:user
      - <path to ReportGenerator> -target:tests.bat -reports:results.xml -targetdir:coverage
    


