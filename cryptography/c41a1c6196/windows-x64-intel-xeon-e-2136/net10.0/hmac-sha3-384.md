| Description                                     | TestDataSize | Mean       | Error     | StdDev    | Median     | Code Size | Allocated |
|------------------------------------------------ |------------- |-----------:|----------:|----------:|-----------:|----------:|----------:|
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 128B         |   1.772 μs | 0.0047 μs | 0.0088 μs |   1.771 μs |   7,013 B |         - |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 128B         |   2.136 μs | 0.0059 μs | 0.0106 μs |   2.134 μs |   1,458 B |         - |
|                                                 |              |            |           |           |            |           |           |
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 137B         |   1.778 μs | 0.0059 μs | 0.0109 μs |   1.776 μs |   7,014 B |         - |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 137B         |   2.124 μs | 0.0050 μs | 0.0086 μs |   2.124 μs |   1,458 B |         - |
|                                                 |              |            |           |           |            |           |           |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 1KB          |   5.434 μs | 0.0151 μs | 0.0283 μs |   5.426 μs |   1,458 B |         - |
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 1KB          |   6.199 μs | 0.0140 μs | 0.0253 μs |   6.187 μs |   6,959 B |         - |
|                                                 |              |            |           |           |            |           |           |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 1025B        |   5.421 μs | 0.0130 μs | 0.0240 μs |   5.417 μs |   1,458 B |         - |
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 1025B        |   6.203 μs | 0.0177 μs | 0.0327 μs |   6.197 μs |   6,965 B |         - |
|                                                 |              |            |           |           |            |           |           |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 8KB          |  33.307 μs | 0.1204 μs | 0.2262 μs |  33.235 μs |   1,458 B |         - |
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 8KB          |  44.291 μs | 0.1290 μs | 0.2455 μs |  44.249 μs |   6,957 B |         - |
|                                                 |              |            |           |           |            |           |           |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 128KB        | 510.210 μs | 2.2012 μs | 4.1881 μs | 508.698 μs |   1,458 B |         - |
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 128KB        | 694.478 μs | 2.0957 μs | 3.9362 μs | 693.833 μs |   6,963 B |         - |