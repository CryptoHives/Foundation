| Description                                   | TestDataSize | Mean         | Error       | StdDev       | Median       | Allocated |
|---------------------------------------------- |------------- |-------------:|------------:|-------------:|-------------:|----------:|
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 128B         |     906.5 ns |    17.95 ns |     17.63 ns |     912.4 ns |         - |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 128B         |   1,028.7 ns |     6.89 ns |      5.76 ns |   1,026.3 ns |         - |
| ComputeMac · HMAC-SHA384 · OS                 | 128B         |   1,195.9 ns |     1.46 ns |      1.29 ns |   1,195.7 ns |     368 B |
|                                               |              |              |             |              |              |           |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 137B         |     913.4 ns |     0.73 ns |      0.61 ns |     913.3 ns |         - |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 137B         |   1,026.1 ns |     2.24 ns |      1.98 ns |   1,026.6 ns |         - |
| ComputeMac · HMAC-SHA384 · OS                 | 137B         |   1,175.1 ns |     1.87 ns |      1.66 ns |   1,174.8 ns |     384 B |
|                                               |              |              |             |              |              |           |
| ComputeMac · HMAC-SHA384 · OS                 | 1KB          |   1,670.0 ns |     6.33 ns |      5.29 ns |   1,670.9 ns |    1264 B |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 1KB          |   2,416.7 ns |    41.33 ns |     57.94 ns |   2,391.6 ns |         - |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 1KB          |   2,886.6 ns |    48.34 ns |     45.22 ns |   2,910.0 ns |         - |
|                                               |              |              |             |              |              |           |
| ComputeMac · HMAC-SHA384 · OS                 | 1025B        |   1,645.0 ns |     6.76 ns |      6.32 ns |   1,647.8 ns |    1272 B |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 1025B        |   2,404.1 ns |    37.67 ns |     31.45 ns |   2,394.4 ns |         - |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 1025B        |   2,851.7 ns |    55.95 ns |     80.24 ns |   2,884.9 ns |         - |
|                                               |              |              |             |              |              |           |
| ComputeMac · HMAC-SHA384 · OS                 | 8KB          |   5,632.7 ns |    31.35 ns |     29.32 ns |   5,631.8 ns |    8432 B |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 8KB          |  13,740.5 ns |   269.79 ns |    369.29 ns |  13,497.0 ns |         - |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 8KB          |  18,697.4 ns |   369.55 ns |    410.76 ns |  18,955.9 ns |         - |
|                                               |              |              |             |              |              |           |
| ComputeMac · HMAC-SHA384 · OS                 | 128KB        |  80,022.2 ns |   465.80 ns |    435.71 ns |  79,818.5 ns |  131340 B |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 128KB        | 201,982.8 ns |   529.83 ns |    442.43 ns | 202,100.8 ns |         - |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 128KB        | 287,841.6 ns | 5,659.11 ns | 11,170.53 ns | 294,966.5 ns |         - |