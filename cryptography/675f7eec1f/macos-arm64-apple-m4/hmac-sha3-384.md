| Description                                     | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 128B         |     510.8 ns |   2.08 ns |   1.95 ns |         - |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 128B         |     779.9 ns |   1.86 ns |   1.74 ns |         - |
|                                                 |              |              |           |           |           |
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 137B         |     509.3 ns |   1.07 ns |   0.95 ns |         - |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 137B         |     778.7 ns |   1.93 ns |   1.80 ns |         - |
|                                                 |              |              |           |           |           |
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 1KB          |   1,749.9 ns |   7.10 ns |   5.93 ns |         - |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 1KB          |   1,976.6 ns |   4.25 ns |   3.97 ns |         - |
|                                                 |              |              |           |           |           |
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 1025B        |   1,753.6 ns |   3.22 ns |   2.69 ns |         - |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 1025B        |   1,976.6 ns |   2.54 ns |   2.12 ns |         - |
|                                                 |              |              |           |           |           |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 8KB          |  12,308.6 ns |  10.93 ns |  10.22 ns |         - |
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 8KB          |  12,659.3 ns |  17.25 ns |  14.41 ns |         - |
|                                                 |              |              |           |           |           |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 128KB        | 191,621.7 ns | 123.99 ns | 115.98 ns |         - |
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 128KB        | 194,948.3 ns | 865.85 ns | 723.02 ns |         - |