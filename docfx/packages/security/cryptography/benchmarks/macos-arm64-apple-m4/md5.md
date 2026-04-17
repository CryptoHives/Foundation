| Description                               | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · MD5 · BouncyCastle       | 128B         |     335.5 ns |   1.28 ns |   1.07 ns |         - |
| TryComputeHash · MD5 · OS Native          | 128B         |     419.5 ns |   1.72 ns |   1.44 ns |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 128B         |     469.1 ns |   0.41 ns |   0.34 ns |         - |
|                                           |              |              |           |           |           |
| TryComputeHash · MD5 · BouncyCastle       | 137B         |     331.9 ns |   1.67 ns |   1.48 ns |         - |
| TryComputeHash · MD5 · OS Native          | 137B         |     402.1 ns |   2.36 ns |   2.09 ns |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 137B         |     469.7 ns |   0.31 ns |   0.26 ns |         - |
|                                           |              |              |           |           |           |
| TryComputeHash · MD5 · OS Native          | 1KB          |   1,419.8 ns |   5.90 ns |   4.60 ns |         - |
| TryComputeHash · MD5 · BouncyCastle       | 1KB          |   1,884.2 ns |   2.36 ns |   1.97 ns |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 1KB          |   2,730.7 ns |   3.76 ns |   2.93 ns |         - |
|                                           |              |              |           |           |           |
| TryComputeHash · MD5 · OS Native          | 1025B        |   1,413.2 ns |   5.90 ns |   5.23 ns |         - |
| TryComputeHash · MD5 · BouncyCastle       | 1025B        |   1,881.6 ns |   3.13 ns |   2.78 ns |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 1025B        |   2,732.9 ns |   2.92 ns |   2.44 ns |         - |
|                                           |              |              |           |           |           |
| TryComputeHash · MD5 · OS Native          | 8KB          |   9,347.7 ns |  37.06 ns |  34.67 ns |         - |
| TryComputeHash · MD5 · BouncyCastle       | 8KB          |  14,312.9 ns |  35.96 ns |  30.03 ns |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 8KB          |  20,836.6 ns |  32.57 ns |  27.20 ns |         - |
|                                           |              |              |           |           |           |
| TryComputeHash · MD5 · OS Native          | 128KB        | 146,095.1 ns | 831.77 ns | 737.35 ns |         - |
| TryComputeHash · MD5 · BouncyCastle       | 128KB        | 227,240.6 ns | 649.73 ns | 542.55 ns |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 128KB        | 331,133.5 ns | 331.07 ns | 293.48 ns |         - |