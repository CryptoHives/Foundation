| Description                               | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · MD5 · BouncyCastle       | 128B         |     328.2 ns |     1.23 ns |     1.15 ns |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 128B         |     356.1 ns |     1.43 ns |     1.34 ns |         - |
| TryComputeHash · MD5 · OS Native          | 128B         |     405.9 ns |     1.91 ns |     1.79 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · MD5 · BouncyCastle       | 137B         |     329.4 ns |     1.45 ns |     1.36 ns |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 137B         |     355.4 ns |     1.67 ns |     1.48 ns |         - |
| TryComputeHash · MD5 · OS Native          | 137B         |     393.6 ns |     1.34 ns |     1.26 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · MD5 · OS Native          | 1KB          |   1,381.8 ns |     6.40 ns |     5.98 ns |         - |
| TryComputeHash · MD5 · BouncyCastle       | 1KB          |   1,839.5 ns |     9.37 ns |     8.77 ns |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 1KB          |   2,087.4 ns |    35.24 ns |    49.40 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · MD5 · OS Native          | 1025B        |   1,382.8 ns |     5.02 ns |     4.70 ns |         - |
| TryComputeHash · MD5 · BouncyCastle       | 1025B        |   1,836.0 ns |     8.48 ns |     7.93 ns |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 1025B        |   2,047.5 ns |    10.18 ns |     9.53 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · MD5 · OS Native          | 8KB          |   9,178.9 ns |    20.90 ns |    19.55 ns |         - |
| TryComputeHash · MD5 · BouncyCastle       | 8KB          |  13,900.9 ns |    71.98 ns |    67.33 ns |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 8KB          |  15,597.3 ns |    58.10 ns |    54.35 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · MD5 · OS Native          | 128KB        | 142,968.9 ns |   289.75 ns |   271.04 ns |         - |
| TryComputeHash · MD5 · BouncyCastle       | 128KB        | 221,003.1 ns |   900.73 ns |   842.55 ns |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 128KB        | 247,478.4 ns | 1,090.37 ns | 1,019.93 ns |         - |