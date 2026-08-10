| Description                               | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · MD5 · OS Native          | 128B         |     268.4 ns |   0.57 ns |   0.54 ns |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 128B         |     309.1 ns |   3.11 ns |   2.91 ns |         - |
| TryComputeHash · MD5 · BouncyCastle       | 128B         |     368.9 ns |   0.49 ns |   0.46 ns |         - |
|                                           |              |              |           |           |           |
| TryComputeHash · MD5 · OS Native          | 137B         |     266.4 ns |   0.28 ns |   0.23 ns |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 137B         |     312.8 ns |   1.63 ns |   1.45 ns |         - |
| TryComputeHash · MD5 · BouncyCastle       | 137B         |     369.1 ns |   0.87 ns |   0.72 ns |         - |
|                                           |              |              |           |           |           |
| TryComputeHash · MD5 · OS Native          | 1KB          |   1,377.6 ns |   1.87 ns |   1.75 ns |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 1KB          |   1,713.9 ns |  10.44 ns |   9.25 ns |         - |
| TryComputeHash · MD5 · BouncyCastle       | 1KB          |   2,011.5 ns |   4.96 ns |   4.40 ns |         - |
|                                           |              |              |           |           |           |
| TryComputeHash · MD5 · OS Native          | 1025B        |   1,369.2 ns |   1.59 ns |   1.41 ns |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 1025B        |   1,715.1 ns |   8.07 ns |   7.55 ns |         - |
| TryComputeHash · MD5 · BouncyCastle       | 1025B        |   2,013.3 ns |   4.85 ns |   4.30 ns |         - |
|                                           |              |              |           |           |           |
| TryComputeHash · MD5 · OS Native          | 8KB          |  10,155.2 ns |  10.60 ns |   9.92 ns |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 8KB          |  12,895.3 ns |  76.00 ns |  67.38 ns |         - |
| TryComputeHash · MD5 · BouncyCastle       | 8KB          |  15,144.2 ns |  24.49 ns |  21.71 ns |         - |
|                                           |              |              |           |           |           |
| TryComputeHash · MD5 · OS Native          | 128KB        | 160,835.1 ns | 167.68 ns | 156.85 ns |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 128KB        | 204,922.0 ns | 896.17 ns | 838.28 ns |         - |
| TryComputeHash · MD5 · BouncyCastle       | 128KB        | 240,671.1 ns | 915.29 ns | 811.38 ns |         - |