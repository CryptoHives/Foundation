| Description                                     | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 128B         |     495.5 ns |   3.21 ns |   2.68 ns |         - |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 128B         |     787.2 ns |   2.01 ns |   1.88 ns |         - |
|                                                 |              |              |           |           |           |
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 137B         |     498.2 ns |   2.54 ns |   1.98 ns |         - |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 137B         |     784.6 ns |   1.27 ns |   1.19 ns |         - |
|                                                 |              |              |           |           |           |
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 1KB          |   1,714.6 ns |   8.86 ns |   7.40 ns |         - |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 1KB          |   1,979.0 ns |   7.54 ns |   7.06 ns |         - |
|                                                 |              |              |           |           |           |
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 1025B        |   1,716.9 ns |  11.89 ns |  11.12 ns |         - |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 1025B        |   1,979.0 ns |   6.25 ns |   5.84 ns |         - |
|                                                 |              |              |           |           |           |
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 8KB          |  12,119.5 ns |  86.77 ns |  72.46 ns |         - |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 8KB          |  12,307.0 ns |  45.24 ns |  42.32 ns |         - |
|                                                 |              |              |           |           |           |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 128KB        | 190,916.1 ns | 560.19 ns | 524.00 ns |         - |
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 128KB        | 191,074.1 ns | 991.93 ns | 879.32 ns |         - |