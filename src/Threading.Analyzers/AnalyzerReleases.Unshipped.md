### New Rules

Rule ID | Category | Severity | Notes
--------|----------|----------|-------
CHT011 | Usage | Warning | async method only forwards an awaited ValueTask
CHT012 | Usage | Info | async ValueTask wrapper boxes a state machine when it suspends

### Removed Rules

Rule ID | Category | Severity | Notes
--------|----------|----------|-------
CHT004 | Usage | Error | Removed - never reported. The rule had no detection code, and the scenario it named is already covered by CHT001: AsTask() consumes a ValueTask exactly as await does, so a second AsTask() on the same instance reports CHT001.
CHT006 | Usage | Warning | Removed - unreachable. It matched a ValueTask argument to Task.WhenAll/WhenAny/WaitAll/WaitAny or ValueTask.WhenAll/WhenAny; the Task overloads take Task, so such a call does not compile, and the ValueTask overloads do not exist. The type system already enforces what the rule described.
