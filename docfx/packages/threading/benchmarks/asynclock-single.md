| Method                             | Mean       | Ratio | Allocated | 
|----------------------------------- |-----------:|------:|----------:|
| IncrementSingle                    |  0.0051 ns | 0.000 |         - | 
| InterlockedIncrementSingle         |  0.1780 ns | 0.015 |         - | 
| LockEnterScopeSingle               |  3.1498 ns | 0.261 |         - | 
| LockUnlockSingle                   |  3.2406 ns | 0.269 |         - | 
| ObjectLockUnlockSingle             |  3.9122 ns | 0.324 |         - | 
| LockUnlockPooledSingleAsync        | 12.0646 ns | 1.000 |         - | 
| LockUnlockSemaphoreSlimSingleAsync | 17.4482 ns | 1.446 |         - | 
| LockUnlockRefImplSingleAsync       | 18.6123 ns | 1.543 |         - | 
| LockUnlockNonKeyedSingleAsync      | 21.8188 ns | 1.809 |         - | 
| LockUnlockNitoSingleAsync          | 38.0193 ns | 3.152 |     320 B | 
| LockUnlockNeoSmartSingleAsync      | 55.4943 ns | 4.600 |     208 B |