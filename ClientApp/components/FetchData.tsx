import * as React from 'react';
import { Link, RouteComponentProps } from 'react-router-dom';
import { connect } from 'react-redux';
import { ApplicationState } from '../store';
import * as WeatherForecastsState from '../store/WeatherForecasts';

// At runtime, Redux will merge together...
type WeatherForecastProps =
    WeatherForecastsState.WeatherForecastsState        // ... state we've requested from the Redux store
    & typeof WeatherForecastsState.actionCreators      // ... plus action creators we've requested
    & RouteComponentProps<{ startDateIndex: string }>; // ... plus incoming routing parameters   

interface State {
    selectedValue: Map<string, Set<string>>;
}

class FetchData extends React.Component<WeatherForecastProps, State> {
    public state: State = {
        selectedValue: new Map<string, Set<string>>()
    }

    componentWillMount() {
        // This method runs when the component is first added to the page
        let startDateIndex = parseInt(this.props.match.params.startDateIndex) || 0;
        this.props.requestWeatherForecasts(startDateIndex);
    }

    componentWillReceiveProps(nextProps: WeatherForecastProps) {
        // This method runs when incoming props (e.g., route params) change
        let startDateIndex = parseInt(nextProps.match.params.startDateIndex) || 0;
        this.props.requestWeatherForecasts(startDateIndex);
    }

    public selectRadioButton(id: number, answer: string) {
        let selectedValue = this.state.selectedValue;
        selectedValue[id] = answer;
        this.setState({ selectedValue: selectedValue });
    }

    public selectCheckbox(id: number, val: string) {
        let selectedValue = this.state.selectedValue;
        let set = new Set<string>(selectedValue.get(id.toString()));
        if (set.has(val)) {
            set.delete(val)
            selectedValue.set(id.toString(), set);
        } else {
            selectedValue.set(id.toString(), set.add(val));
        }
        this.setState({ selectedValue: selectedValue });
    }

    private hasValue(value: string, id: string) {
        if (this.state.selectedValue.has(id)) {
            return this.state.selectedValue.get(id).has(value);
        }
        return false;
    }

    public render() {
        return <div>
            <h1 className="text-primary">
                Introductory Assessment
            </h1>
            <div className="col-xs-10">
                {this.renderQuestions()}
            </div>

            <div className="col-xs-2">
                <div className="list-group">
                    {this.renderQuestionsPool()}
                </div>
            </div>
            <div className="row">
                <div className="col-xs-12">
                    {this.renderPagination()}
                </div>
            </div>

        </div>;
    }

    private renderQuestionsPool() {
        return <div>
            {this.props.forecasts.map(forecast =>
                <a key={forecast.id} href="#" className="list-group-item">Question #{forecast.id}</a>
            )}
        </div>;
    }

    private renderInput(value: string, format: number, answer: string, id: number) {
        if (format == 2) {
            return <label htmlFor={value + "-" + id}>
                <input id={value + "-" + id}
                    type="checkbox"
                    checked={this.hasValue(value, id.toString())}
                    onClick={() => this.selectCheckbox(id, value)}
                    value={value} />{answer}
            </label>;
        }
        else {
            return <label htmlFor={value + "-" + id} onClick={() => this.selectRadioButton(id, answer)}>
                <input id={value + "-" + id}
                    checked={this.state.selectedValue[id] === answer}
                    type="radio"
                    value={value} />{answer}
            </label>
        }
    }

    private renderQuestions() {
        return <div>
            {this.props.forecasts.map(forecast =>
                <div className="row well well-lg form-group" key={forecast.id}>
                    <h4><strong>{forecast.variation1}</strong></h4>
                    <br />
                    {forecast.answer1 ?
                        <div className="col-xs-3">
                            {this.renderInput("1", forecast.format, forecast.answer1, forecast.id)}
                        </div> : ""}
                    {forecast.answer2 ?
                        <div className="col-xs-3">
                            {this.renderInput("2", forecast.format, forecast.answer2, forecast.id)}
                        </div> : ""}
                    {forecast.answer3 ?
                        <div className="col-xs-3">
                            {this.renderInput("3", forecast.format, forecast.answer3, forecast.id)}
                        </div> : ""}
                    {forecast.answer4 ?
                        <div className="col-xs-3">
                            {this.renderInput("4", forecast.format, forecast.answer4, forecast.id)}
                        </div> : ""}
                </div>
            )}
        </div>;
    }

    private renderPagination() {
        let prevStartDateIndex = this.props.startDateIndex - 5;
        let nextStartDateIndex = this.props.startDateIndex + 5;

        return <p className='clearfix text-center'>
            <Link className='btn btn-default pull-left' to={`/fetchdata/${prevStartDateIndex}`}>Previous</Link>
            <Link className='btn btn-default pull-right' to={`/fetchdata/${nextStartDateIndex}`}>Next</Link>
            {this.props.isLoading ? <span>Loading...</span> : []}
        </p>;
    }
}

export default connect(
    (state: ApplicationState) => state.weatherForecasts, // Selects which state properties are merged into the component's props
    WeatherForecastsState.actionCreators                 // Selects which action creators are merged into the component's props
)(FetchData) as typeof FetchData;
