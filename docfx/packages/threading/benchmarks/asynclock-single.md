| Description                           | Mean       | Ratio | Allocated | 
|-------------------------------------- |-----------:|------:|----------:|
| Lock · Increment · System             |  0.0015 ns | 0.000 |         - | 
| Lock · Interlocked.Increment · System |  0.1768 ns | 0.015 |         - | 
| Lock · Lock.EnterScope · System       |  3.1452 ns | 0.267 |         - | 
| Lock · Lock · System                  |  3.1464 ns | 0.267 |         - | 
| Lock · lock() · System                |  3.8143 ns | 0.324 |         - | 
| LockAsync · AsyncLock · Pooled        | 11.7767 ns | 1.000 |         - | 
| LockAsync · SemaphoreSlim · System    | 16.7896 ns | 1.426 |         - | 
| LockAsync · AsyncLock · RefImpl       | 18.2543 ns | 1.550 |         - | 
| LockAsync · AsyncLock · NonKeyed      | 21.3334 ns | 1.812 |         - | 
| LockAsync · AsyncLock · Nito.AsyncEx  | 41.8880 ns | 3.557 |     320 B | 
| LockAsync · AsyncLock · NeoSmart      | 56.0962 ns | 4.763 |     208 B |