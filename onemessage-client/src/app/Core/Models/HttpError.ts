export interface NormalizedName {}

export interface Header {}

export interface Header {
	normalizedNames: NormalizedName;
	lazyUpdate?: any;
	headers: Header;
}

export interface Error {
	type: string;
	title: string;
	status: number;
	detail: string;
}

export interface HttpError {
	headers: Header;
	status: number;
	statusText: string;
	url: string;
	ok: boolean;
	name: string;
	message: string;
	error: Error;
}