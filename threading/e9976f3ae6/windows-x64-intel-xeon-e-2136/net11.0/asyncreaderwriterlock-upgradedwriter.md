| Description                                       | Iterations | cancellationType | Mean         | Error      | StdDev     | Ratio | Allocated | 
|-------------------------------------------------- |----------- |----------------- |-------------:|-----------:|-----------:|------:|----------:|
| UpgradedWriterLock · AsyncRWLock · RWLockSlim     | 0          | None             |     44.88 ns |   0.017 ns |   0.032 ns |  0.68 |         - | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 0          | None             |     62.48 ns |   0.153 ns |   0.291 ns |  0.95 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 0          | None             |     65.53 ns |   0.182 ns |   0.324 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 0          | None             |  2,978.76 ns |  10.509 ns |  18.679 ns | 45.46 |     728 B | 
|                                                   |            |                  |              |            |            |       |           | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 0          | NotCancelled     |     62.56 ns |   0.167 ns |   0.310 ns |  0.95 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 0          | NotCancelled     |     65.74 ns |   0.304 ns |   0.555 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 0          | NotCancelled     |  3,026.17 ns |  28.299 ns |  52.454 ns | 46.04 |     728 B | 
|                                                   |            |                  |              |            |            |       |           | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 0          | Timed            |     65.38 ns |   0.208 ns |   0.391 ns |  1.00 |         - | 
|                                                   |            |                  |              |            |            |       |           | 
| UpgradedWriterLock · AsyncRWLock · RWLockSlim     | 1          | None             |     65.32 ns |   0.018 ns |   0.034 ns |  0.35 |         - | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 1          | None             |    136.08 ns |   0.218 ns |   0.399 ns |  0.73 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 1          | None             |    187.04 ns |   0.731 ns |   1.373 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 1          | None             |  4,385.99 ns |  57.274 ns | 106.162 ns | 23.45 |     960 B | 
|                                                   |            |                  |              |            |            |       |           | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 1          | NotCancelled     |    204.15 ns |   0.114 ns |   0.216 ns |  0.91 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 1          | NotCancelled     |    223.33 ns |   2.389 ns |   4.487 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 1          | NotCancelled     |  4,589.79 ns |  40.593 ns |  77.232 ns | 20.56 |     960 B | 
|                                                   |            |                  |              |            |            |       |           | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 1          | Timed            |    283.89 ns |   0.987 ns |   1.806 ns |  1.00 |     152 B | 
|                                                   |            |                  |              |            |            |       |           | 
| UpgradedWriterLock · AsyncRWLock · RWLockSlim     | 2          | None             |     85.04 ns |   0.066 ns |   0.121 ns |  0.33 |         - | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 2          | None             |    155.79 ns |   0.612 ns |   1.163 ns |  0.60 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 2          | None             |    259.32 ns |   1.554 ns |   2.881 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 2          | None             |  6,225.90 ns | 199.121 ns | 373.998 ns | 24.01 |    1168 B | 
|                                                   |            |                  |              |            |            |       |           | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 2          | NotCancelled     |    226.49 ns |   0.676 ns |   1.253 ns |  0.77 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 2          | NotCancelled     |    295.03 ns |   0.924 ns |   1.735 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 2          | NotCancelled     |  6,044.14 ns | 116.301 ns | 215.572 ns | 20.49 |    1168 B | 
|                                                   |            |                  |              |            |            |       |           | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 2          | Timed            |    357.52 ns |   0.922 ns |   1.709 ns |  1.00 |     152 B | 
|                                                   |            |                  |              |            |            |       |           | 
| UpgradedWriterLock · AsyncRWLock · RWLockSlim     | 5          | None             |    140.11 ns |   1.817 ns |   3.545 ns |  0.29 |         - | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 5          | None             |    215.85 ns |   0.390 ns |   0.723 ns |  0.45 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 5          | None             |    478.27 ns |   1.269 ns |   2.320 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 5          | None             | 12,017.84 ns | 463.158 ns | 881.205 ns | 25.13 |    1792 B | 
|                                                   |            |                  |              |            |            |       |           | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 5          | NotCancelled     |    295.94 ns |   2.167 ns |   3.908 ns |  0.57 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 5          | NotCancelled     |    517.48 ns |   2.382 ns |   4.415 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 5          | NotCancelled     | 11,661.32 ns |  99.395 ns | 189.109 ns | 22.54 |    1792 B | 
|                                                   |            |                  |              |            |            |       |           | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 5          | Timed            |    581.64 ns |   1.555 ns |   2.844 ns |  1.00 |     152 B |