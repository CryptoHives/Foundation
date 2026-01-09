@echo off
REM update-benchmark-docs.cmd
REM Copies BenchmarkDotNet results to docfx benchmark documentation folder
REM Run this after executing benchmarks locally on a quiet machine

setlocal enabledelayedexpansion

set "SOURCE=tests\Threading\BenchmarkDotNet.Artifacts\results"
set "DEST=docfx\packages\threading\benchmarks"

echo.
echo ========================================
echo  Updating Benchmark Documentation
echo ========================================
echo.
echo Source: %SOURCE%
echo Destination: %DEST%
echo.

if not exist "%SOURCE%" (
    echo ERROR: Source directory does not exist.
    echo Please run benchmarks first:
    echo   cd tests\Threading
    echo   dotnet run -c Release -- --filter "*Benchmark*"
    exit /b 1
)

if not exist "%DEST%" (
    echo Creating destination directory...
    mkdir "%DEST%"
)

echo Copying benchmark results...
echo.

REM AsyncLock benchmarks
call :CopyBenchmark "AsyncLockSingleBenchmark" "asynclock-single.md"
call :CopyBenchmark "AsyncLockMultipleBenchmark" "asynclock-multiple.md"

REM AsyncAutoResetEvent benchmarks
call :CopyBenchmark "AsyncAutoResetEventSetBenchmark" "asyncautoresetevent-set.md"
call :CopyBenchmark "AsyncAutoResetEventSetThenWaitBenchmark" "asyncautoresetevent-setthenw.md"
call :CopyBenchmark "AsyncAutoResetEventWaitThenSetBenchmark" "asyncautoresetevent-waitthenset.md"

REM AsyncManualResetEvent benchmarks
call :CopyBenchmark "AsyncManualResetEventSetResetBenchmark" "asyncmanualresetevent-setreset.md"
call :CopyBenchmark "AsyncManualResetEventSetThenWaitBenchmark" "asyncmanualresetevent-setthenw.md"
call :CopyBenchmark "AsyncManualResetEventWaitThenSetBenchmark" "asyncmanualresetevent-waitthenset.md"

REM AsyncSemaphore benchmarks
call :CopyBenchmark "AsyncSemaphoreSingleBenchmark" "asyncsemaphore-single.md"

REM AsyncCountdownEvent benchmarks
call :CopyBenchmark "AsyncCountdownEventSignalBenchmark" "asynccountdownevent-signal.md"

REM AsyncBarrier benchmarks
call :CopyBenchmark "AsyncBarrierSignalAndWaitBenchmark" "asyncbarrier-signalandwait.md"

REM AsyncReaderWriterLock benchmarks
call :CopyBenchmark "AsyncReaderWriterLockReaderBenchmark" "asyncreaderwriterlock-reader.md"
call :CopyBenchmark "AsyncReaderWriterLockWriterBenchmark" "asyncreaderwriterlock-writer.md"

echo.
echo ========================================
echo  Benchmark documentation updated!
echo ========================================
echo.
echo Next steps:
echo   1. Review the updated files in %DEST%
echo   2. Build docfx to verify: docfx docfx\docfx.json
echo   3. Commit the changes
echo.

exit /b 0

:CopyBenchmark
set "BENCHMARK_NAME=%~1"
set "TARGET_NAME=%~2"
set "SRC_FILE=%SOURCE%\Threading.Tests.Async.Pooled.%BENCHMARK_NAME%-report-github.md"

if exist "%SRC_FILE%" (
    echo   [OK] %TARGET_NAME%
    copy /Y "%SRC_FILE%" "%DEST%\%TARGET_NAME%" >nul
) else (
    echo   [--] %TARGET_NAME% (not found: %BENCHMARK_NAME%)
)
exit /b 0
