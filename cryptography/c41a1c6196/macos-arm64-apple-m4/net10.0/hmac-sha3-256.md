| Description                                     | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 128B         |     359.4 ns |   0.77 ns |   0.64 ns |         - |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 128B         |     636.3 ns |   0.58 ns |   0.55 ns |         - |
|                                                 |              |              |           |           |           |
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 137B         |     497.6 ns |   2.65 ns |   2.48 ns |         - |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 137B         |     793.3 ns |   0.49 ns |   0.43 ns |         - |
|                                                 |              |              |           |           |           |
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 1KB          |   1,426.8 ns |   8.90 ns |   8.32 ns |         - |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 1KB          |   1,692.4 ns |   0.90 ns |   0.79 ns |         - |
|                                                 |              |              |           |           |           |
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 1025B        |   1,415.0 ns |   3.22 ns |   2.69 ns |         - |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 1025B        |   1,692.4 ns |   1.89 ns |   1.77 ns |         - |
|                                                 |              |              |           |           |           |
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 8KB          |   9,439.0 ns |  34.37 ns |  30.46 ns |         - |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 8KB          |   9,647.6 ns |   9.24 ns |   8.65 ns |         - |
|                                                 |              |              |           |           |           |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 128KB        | 146,030.0 ns | 170.45 ns | 151.10 ns |         - |
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 128KB        | 150,633.6 ns | 674.95 ns | 563.61 ns |         - |