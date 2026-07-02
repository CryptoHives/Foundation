| Description                                       | Iterations | cancellationType | Mean        | Ratio | Allocated | 
|-------------------------------------------------- |----------- |----------------- |------------:|------:|----------:|
| UpgradedWriterLock · RWLockSlim · System          | 0          | None             |    10.47 ns |  0.65 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 0          | None             |    16.14 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 0          | None             |    21.60 ns |  1.34 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 0          | None             | 1,506.85 ns | 93.37 |     824 B | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 0          | NotCancelled     |    16.88 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 0          | NotCancelled     |    18.75 ns |  1.11 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 0          | NotCancelled     | 1,589.77 ns | 94.16 |     824 B | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · RWLockSlim · System          | 1          | None             |    16.90 ns |  0.26 |         - | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 1          | None             |    31.62 ns |  0.49 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 1          | None             |    64.84 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 1          | None             | 1,823.41 ns | 28.12 |    1032 B | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 1          | NotCancelled     |    43.38 ns |  0.63 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 1          | NotCancelled     |    68.99 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 1          | NotCancelled     | 1,924.42 ns | 27.90 |    1032 B | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · RWLockSlim · System          | 2          | None             |    21.11 ns |  0.16 |         - | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 2          | None             |    34.82 ns |  0.27 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 2          | None             |   131.26 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 2          | None             | 2,117.06 ns | 16.13 |    1240 B | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 2          | NotCancelled     |    46.96 ns |  0.35 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 2          | NotCancelled     |   132.91 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 2          | NotCancelled     | 2,209.27 ns | 16.62 |    1240 B | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · RWLockSlim · System          | 5          | None             |    33.79 ns |  0.11 |         - | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 5          | None             |    45.85 ns |  0.15 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 5          | None             |   312.28 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 5          | None             | 3,217.76 ns | 10.30 |    1864 B | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 5          | NotCancelled     |    59.14 ns |  0.19 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 5          | NotCancelled     |   312.00 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 5          | NotCancelled     | 3,305.58 ns | 10.59 |    1864 B |