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
CHT010 | Usage | Warning | ValueTask captured in lambda/closure

## Release 0.7

### New Rules

Rule ID | Category | Severity | Notes
--------|----------|----------|-------
CHT011 | Usage | Warning | async method only forwards an awaited ValueTask
CHT012 | Usage | Info | async ValueTask wrapper boxes a state machine when it suspends
CHT013 | Usage | Warning | async method returns an AsyncReentrantLock releaser

### Removed Rules

Rule ID | Category | Severity | Notes
--------|----------|----------|-------
CHT004 | Usage | Error | Removed - never reported. The rule had no detection code, and the scenario it named is already covered by CHT001: AsTask() consumes a ValueTask exactly as await does, so a second AsTask() on the same instance reports CHT001.
CHT006 | Usage | Warning | Removed - unreachable. It matched a ValueTask argument to Task.WhenAll/WhenAny/WaitAll/WaitAny or ValueTask.WhenAll/WhenAny; the Task overloads take Task, so such a call does not compile, and the ValueTask overloads do not exist. The type system already enforces what the rule described.
