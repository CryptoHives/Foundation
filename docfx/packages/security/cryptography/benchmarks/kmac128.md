| Description          | TestDataSize | Mean         | Error       | StdDev    | Allocated |
|--------------------- |------------- |-------------:|------------:|----------:|----------:|
| Kmac128_DotNet       | 128B         |     982.0 ns |    10.09 ns |   8.42 ns |      32 B |
| Kmac128_CryptoHives  | 128B         |   1,242.3 ns |     5.66 ns |   5.30 ns |    2088 B |
| Kmac128_BouncyCastle | 128B         |   1,317.4 ns |    13.82 ns |  12.92 ns |     160 B |
|                      |              |              |             |           |           |
| Kmac128_DotNet       | 137B         |     980.1 ns |     7.83 ns |   7.32 ns |      32 B |
| Kmac128_CryptoHives  | 137B         |   1,241.0 ns |     5.09 ns |   4.76 ns |    2088 B |
| Kmac128_BouncyCastle | 137B         |   1,314.7 ns |     6.89 ns |   6.10 ns |     160 B |
|                      |              |              |             |           |           |
| Kmac128_DotNet       | 1KB          |   2,371.8 ns |    11.39 ns |   9.51 ns |      32 B |
| Kmac128_CryptoHives  | 1KB          |   2,489.0 ns |    19.24 ns |  17.99 ns |    2088 B |
| Kmac128_BouncyCastle | 1KB          |   3,149.2 ns |    16.03 ns |  15.00 ns |     160 B |
|                      |              |              |             |           |           |
| Kmac128_DotNet       | 1025B        |   2,382.8 ns |    15.14 ns |  13.42 ns |      32 B |
| Kmac128_CryptoHives  | 1025B        |   2,482.7 ns |    12.36 ns |  10.96 ns |    2088 B |
| Kmac128_BouncyCastle | 1025B        |   3,160.7 ns |    15.20 ns |  13.47 ns |     160 B |
|                      |              |              |             |           |           |
| Kmac128_CryptoHives  | 8KB          |  10,827.5 ns |    72.26 ns |  67.59 ns |    2088 B |
| Kmac128_DotNet       | 8KB          |  12,388.5 ns |    81.11 ns |  71.90 ns |      32 B |
| Kmac128_BouncyCastle | 8KB          |  15,995.3 ns |    84.67 ns |  75.06 ns |     160 B |
|                      |              |              |             |           |           |
| Kmac128_CryptoHives  | 128KB        | 155,877.3 ns |   696.12 ns | 617.09 ns |    2088 B |
| Kmac128_DotNet       | 128KB        | 186,083.6 ns | 1,004.61 ns | 890.56 ns |      32 B |
| Kmac128_BouncyCastle | 128KB        | 239,811.0 ns | 1,036.16 ns | 969.22 ns |     160 B |