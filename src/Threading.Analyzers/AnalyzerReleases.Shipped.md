## Release 0.6

### New Rules

Rule ID | Category | Severity | Notes
--------|----------|----------|-------
CHT001 | Usage | Error | ValueTask awaited multiple times
CHT002 | Usage | Warning | ValueTask.GetAwaiter().GetResult() used (blocking)
CHT003 | Usage | Warning | ValueTask stored in field
CHT004 | Usage | Error | ValueTask.AsTask() called multiple times
CHT005 | Usage | Warning | ValueTask.Result accessed directly
CHT006 | Usage | Warning | ValueTask passed to potentially unsafe method
CHT007 | Usage | Info | AsTask() stored before signaling (performance)
CHT008 | Usage | Warning | ValueTask not awaited or consumed
CHT009 | Usage | Info | SemaphoreSlim(1, 1) used as async lock; replace with AsyncLock
CHT010 | Usage | Error | ValueTask captured in lambda/closure