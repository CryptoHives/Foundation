| Description                                        | TestDataSize | Mean         | Error       | StdDev      | Median       | Code Size | Allocated |
|--------------------------------------------------- |------------- |-------------:|------------:|------------:|-------------:|----------:|----------:|
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 128B         |     690.1 ns |    13.83 ns |    32.05 ns |     678.4 ns |   3,998 B |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 128B         |     934.6 ns |    18.70 ns |    34.19 ns |     922.2 ns |   4,920 B |         - |
|                                                    |              |              |             |             |              |           |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 137B         |     717.9 ns |     6.88 ns |     5.74 ns |     716.8 ns |   4,010 B |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 137B         |     942.2 ns |    14.75 ns |    12.32 ns |     934.9 ns |   4,920 B |         - |
|                                                    |              |              |             |             |              |           |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 1KB          |   4,275.9 ns |    11.97 ns |    10.61 ns |   4,274.5 ns |   3,998 B |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 1KB          |   5,723.7 ns |    13.23 ns |    10.33 ns |   5,721.3 ns |   4,920 B |         - |
|                                                    |              |              |             |             |              |           |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 1025B        |   4,283.6 ns |    20.13 ns |    16.81 ns |   4,282.7 ns |   4,010 B |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 1025B        |   5,721.3 ns |     7.36 ns |     6.88 ns |   5,717.1 ns |   4,920 B |         - |
|                                                    |              |              |             |             |              |           |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 8KB          |  33,143.0 ns |    77.71 ns |    68.89 ns |  33,116.3 ns |   4,010 B |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 8KB          |  44,363.3 ns |    45.09 ns |    35.20 ns |  44,351.6 ns |   4,920 B |         - |
|                                                    |              |              |             |             |              |           |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 128KB        | 528,331.6 ns | 1,456.65 ns | 1,362.56 ns | 528,257.2 ns |   3,957 B |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 128KB        | 709,338.2 ns | 1,109.73 ns |   866.40 ns | 709,339.0 ns |   4,920 B |         - |